using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

using Unionized.Contract.Service;
using Unionized.Contract;
using Unionized.Contract.Repository;

namespace Unionized.Service
{
    internal class SessionService : ISessionService
    {
        private readonly ILdapService _ldap = null;
        private readonly UnionizedConfiguration _config = null;
        private readonly ITokenService _tokenSvc = null;
        private readonly IRoleRepository _roleRepo = null;

        public SessionService(ILdapService ldap, IRoleRepository role,
            ITokenService tokenSvc, UnionizedConfiguration config)
        {
            _ldap = ldap;
            _tokenSvc = tokenSvc;
            _config = config;
            _roleRepo = role;
        }

        public async Task<LogonResponse> AuthenticateAsync(LogonRequest request)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            var result = new LogonResponse
            {
                Status = VerificationStatus.Success
            };

            bool isValid = _ldap.ValidateDirectoryUser(request.Username, request.Password);

            if (!isValid)
            {
                result.Status = VerificationStatus.FailedAuthentication;
                return result;
            }

            var ldapUser = _ldap.GetDirectoryUser(request.Username);
            if (ldapUser == null)
                throw new InvalidOperationException("Missing AD user");

            //Invalidate any old tokens
            await _tokenSvc.InvalidateUserTokens(request.Username);
            DateTime expiration = request.Persist ? DateTime.MaxValue : DateTime.Now.AddHours(6);
            RoleType role = await GetRoleFromGroups(ldapUser.MemberOf);

            var tokenRequest = new TokenRequest
            {
                ActiveDirectoryId = ldapUser.Id,
                Audience = "https://unionized.unionsquared.lan", //TODO: Not hardcode
                Email = ldapUser.Email,
                Expiration = expiration,
                Issuer = "Unionized.API", //TODO: Not hardcode
                Persist = request.Persist,
                Role = role,
                Name = ldapUser.Name,
                Username = request.Username
            };
            var userToken = await _tokenSvc.GenerateAuthenticationTokenAsync(tokenRequest);

            result.Email = ldapUser.Email;
            result.FirstName = ldapUser.FirstName;
            result.LastName = ldapUser.LastName;
            result.LogonToken = userToken.TokenString;
            result.Role = role;
            result.Username = request.Username;
            return result;
        }

        public async Task LogoutAsync(string username, string token)
        {
            var userToken = await _tokenSvc.GetTokenByUserAndTokenAsync(username, token);

            if (userToken != null)
            {
                await _tokenSvc.DeleteAsync(userToken.Slug);
            }
        }

        public async Task<bool> ValidateTokenAsync(string token, string username)
        {
            var userToken = await _tokenSvc.GetTokenByUserAndTokenAsync(username, token);

            bool validToken = userToken != null && userToken.Active && userToken.TokenExpiry >= DateTime.Now;

            if (!validToken)
            {
                await _tokenSvc.InvalidateUserTokens(username);
                return false;
            }

            var claims = _tokenSvc.ValidateToken(token, "https://unionized.unionsquared.lan", "Unionized.API"); //TODO: Not hardcode

            return claims != null;
        }

        //CN=SG_Unionized_Admin,CN=Users,DC=unionsquared,DC=lan
        private async Task<RoleType> GetRoleFromGroups(string[] userGroups)
        {
            if (userGroups.Length == 0)
                return RoleType.Nobody;

            string s;
            foreach (var item in userGroups)
            {
                s = item.Substring(0, item.IndexOf(','));
                s = s.Replace("CN=", string.Empty);

                var role = await _roleRepo.GetBySecurityGroup(s);

                if (role != null)
                {
                    return role.Role;
                }
            }

            return RoleType.Nobody;
        }
    }
}
