using System;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace Unionized.Interface.Service
{
    public interface IEncryptionService
    {
        /// <summary>
        /// Verifies the password hash using PBDKF2.
        /// </summary>
        /// <returns><c>true</c>, if password hash was verified, <c>false</c> otherwise.</returns>
        /// <param name="passwordHash">Password hash.</param>
        bool VerifyPasswordHash(byte[] passwordHash);

        /// <summary>
        /// Generate a new password using PBDKF2.
        /// </summary>
        /// <returns>The password hash.</returns>
        /// <param name="plainText">The plain text version of the password</param>
        byte[] GeneratePasswordHash(string plainText);

        /// <summary>
        /// Hash given content using SHA-256 algorithm
        /// </summary>
        /// <param name="content">The content to hash</param>
        /// <returns>The SHA-256 hash of the content</returns>
        string Hash(string content);

        /// <summary>
        /// Load a certificate from the file system
        /// </summary>
        /// <param name="location">The location of the certificate on the filesystem</param>
        /// <param name="certificatePassword">Optional parameter to specify the password for the private key. Usually for PKCS7 or PKCS12 certificates</param>
        /// <returns></returns>
        X509Certificate2 LoadCertificate(string location, string certificatePassword = null);

        /// <summary>
        /// Generates generate a JSON Web Token
        /// </summary>
        /// <returns>The serialized and signed JWT</returns>
        /// <param name="claims">Claims.</param>
        /// <param name="tokenExpiry">The amount of time in minutes the token lasts</param>
        /// <param name="issuer">String to identify the issuer of the token</param>
        /// <param name="audience">The valid audience of the token. This is usually your domain name.</param>
        string GenerateJwt(ClaimsIdentity claims, DateTime tokenExpiry, string issuer, string audience);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="signingCertificate"></param>
        /// <param name="issuer"></param>
        /// <param name="audience"></param>
        /// <returns></returns>
        ClaimsPrincipal ValidateJwt(string token, string issuer, string audience);
    }
}
