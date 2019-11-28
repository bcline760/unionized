using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Unionized.Contract.Service;
using Unionized.Contract;
using System.Security.Claims;

namespace Unionized.Service
{
    public class SessionService : ISessionService
    {
        private ILdap _ldap = null;
        private IEncryptionService _encryption = null;
        private UnionizedConfiguration _config = null;
        private ITokenService _tokenSvc = null;

        public SessionService(ILdap ldap, IEncryptionService encryption,
            ITokenService tokenSvc, UnionizedConfiguration config)
        {
            _ldap = ldap;
            _encryption = encryption;
            _tokenSvc = tokenSvc;
            _config = config;
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

            DateTime expiration = request.Persist ? DateTime.MaxValue : DateTime.Now.AddHours(6);
            RoleType role = GetRoleFromGroups(ldapUser.MemberOf);
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Expiration,expiration.ToString()),
                new Claim(ClaimTypes.IsPersistent,request.Persist.ToString()),
                new Claim(ClaimTypes.Email,ldapUser.EmailAddress),
                new Claim(ClaimTypes.NameIdentifier,request.Username),
                new Claim(ClaimTypes.Name, ldapUser.Name),
                new Claim(ClaimTypes.Role, role.ToString()),
                new Claim(ClaimTypes.Sid, ldapUser.ObjectSid)
            };
            var claimsId = new ClaimsIdentity(claims);
            var certificate = _encryption.LoadCertificate(_config.Certificate.CertificateLocation, _config.Certificate.Password);

            //Make sure the incoming certificate matches what is configured.
            if (certificate.Thumbprint.ToLowerInvariant() != _config.Certificate.Thumbprint.ToLowerInvariant())
                throw new InvalidOperationException("Certificate used does not match the thumbprint configured. This could be a man-in-the-middle attack.");

            var token = _encryption.GenerateJwt(claimsId, expiration, null, certificate);

            var userToken = new UserToken
            {
                Active = true,
                CreatedAt = DateTime.Now,
                TokenExpiry = expiration,
                TokenString = token
            };
            await _tokenSvc.SaveAsync(userToken);

            result.LogonToken = token;
            return result;
        }

        public async Task LogoutAsync(string username)
        {

        }

        //CN=SG_Unionized_Admin,CN=Users,DC=unionsquared,DC=lan
        private RoleType GetRoleFromGroups(string[] userGroups)
        {
            if (userGroups.Length == 0)
                return RoleType.Nobody;

            string s;
            foreach (var item in userGroups)
            {
                s = item.Substring(0, item.IndexOf(','));
                s = s.Replace("CN=", string.Empty);

                if (s == "SG_Unionized_Admin")
                    return RoleType.Admin;
                else if (s == "SG_Unionized_User")
                    return RoleType.User;
            }

            return RoleType.Nobody;
        }
    }
}
