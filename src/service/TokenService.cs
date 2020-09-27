using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;

using Unionized.Contract;
using Unionized.Contract.Repository;
using Unionized.Contract.Service;

namespace Unionized.Service
{
    internal sealed class TokenService : UnionizedService<UserToken>, ITokenService
    {
        private IEncryptionService Encryption { get; }

        private UnionizedConfiguration Config { get; }

        private ITokenRepository Repository { get; }

        public TokenService(ITokenRepository repository, IEncryptionService encryption,
            UnionizedConfiguration config) : base(repository)
        {
            Encryption = encryption;
            Config = config;
            Repository = repository;
        }

        public async Task InvalidateUserTokens(string username)
        {
            var userTokens = await Repository.GetByUserAsync(username);

            var activeTokens = userTokens.Where(a => a.Active).ToList();
            foreach (var token in activeTokens)
            {
                await Repository.DeleteAsync(token.Slug);
            }
        }

        public async Task<UserToken> GenerateAuthenticationTokenAsync(TokenRequest request)
        {
            var certificate = Encryption.LoadCertificate(Config.Certificate.CertificateLocation, Config.Certificate.Password);

            //Make sure the incoming certificate matches what is configured.
            if (certificate.Thumbprint.ToLowerInvariant() != Config.Certificate.Thumbprint.ToLowerInvariant())
                throw new InvalidOperationException("Certificate used does not match the thumbprint configured. This could be a man-in-the-middle attack.");

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Expiration,request.Expiration.ToString()),
                new Claim(ClaimTypes.IsPersistent,request.Persist.ToString()),
                new Claim(ClaimTypes.Role, request.Role.ToString()),
                new Claim(ClaimTypes.NameIdentifier, request.Username),
                new Claim(ClaimTypes.Hash, Encryption.Hash(DateTime.Now.Ticks.ToString()))
            };

            if (!string.IsNullOrEmpty(request.Email))
                claims.Add(new Claim(ClaimTypes.Email, request.Email));
            if (!string.IsNullOrEmpty(request.Name))
                claims.Add(new Claim(ClaimTypes.Name, request.Name));

            var claimsId = new ClaimsIdentity(claims);
            var token = Encryption.GenerateJwt(
                claimsId,
                request.Expiration,
                certificate,
                request.Issuer,
                request.Audience
            );

            var userToken = new UserToken
            {
                CreatedAt = DateTime.Now,
                TokenExpiry = request.Expiration,
                TokenString = token,
                GeneratedBy = request.Username,
                Active = true
            };

            await SaveAsync(userToken);

            return userToken;
        }

        public async Task<UserToken> GetTokenByUserAndTokenAsync(string user, string token)
        {
            var userList = await Repository.GetByUserAsync(user);

            var userToken = userList.FirstOrDefault(t => t.TokenString == token);
            return userToken;
        }

        public ClaimsPrincipal ValidateToken(string token, string audience, string issuer)
        {
            var certificate = Encryption.LoadCertificate(Config.Certificate.CertificateLocation, Config.Certificate.Password);

            var principal = Encryption.ValidateJwt(token, certificate, issuer, audience);

            return principal;
        }
    }
}
