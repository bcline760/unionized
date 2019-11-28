using System;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;

namespace Unionized.Contract.Service
{
    public interface IEncryptionService
    {
        /// <summary>
        /// Encrypt the specified obj.
        /// </summary>
        /// <returns>The encrypted data</returns>
        /// <param name="obj">Generic object which to encrypt. If an object, must be serializable</param>
        /// <typeparam name="T">The type of object to encrypt</typeparam>
        byte[] Encrypt<T>(T obj);

        /// <summary>
        /// Decrypt data
        /// </summary>
        /// <returns>The decrypted object</returns>
        /// <param name="encryptedData">Encrypted data.</param>
        /// <typeparam name="T">The type of object to decrypt</typeparam>
        T Decrypt<T>(byte[] encryptedData);


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
        /// <param name="key">A key used to sign the JWT. If this is not <see langword="null"/>, then a certificate can't be used</param>
        /// <param name="signingCertificate">A certificate to use to sign the JWT. If not provided, a key must be used.</param>
        string GenerateJwt(ClaimsIdentity claims, DateTime tokenExpiry, string key = null, X509Certificate2 signingCertificate = null);
    }
}
