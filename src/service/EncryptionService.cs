using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

using Unionized.Contract.Service;
using Microsoft.IdentityModel.Tokens;

namespace Unionized.Service
{
    public class EncryptionService : IEncryptionService
    {
        public EncryptionService()
        {
        }

        public T Decrypt<T>(byte[] encryptedData)
        {
            throw new NotImplementedException();
        }

        public byte[] Encrypt<T>(T obj)
        {
            throw new NotImplementedException();
        }

        public byte[] GeneratePasswordHash(string plainText)
        {
            byte[] hashedPwd;
            byte[] salt = Encoding.UTF8.GetBytes(Constants.PASSWORD_HASH_SALT);
            using (var rfc = new Rfc2898DeriveBytes(plainText, salt, Constants.PASSWORD_HASH_ITERATIONS))
            {
                hashedPwd = rfc.GetBytes(Constants.PASSWORD_HASH_LENGTH);
            }
            return hashedPwd;
        }

        public string GenerateJwt(ClaimsIdentity claims, DateTime tokenExpiry, string key = null, X509Certificate2 signingCertificate = null)
        {
            SigningCredentials signingCredentials = null;
            if (key != null)
            {
                signingCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.Default.GetBytes(key)),
                        SecurityAlgorithms.HmacSha256Signature);
            }
            else if (signingCertificate != null)
            {
                signingCredentials = new X509SigningCredentials(signingCertificate);
            }
            else if (key != null && signingCertificate != null)
                throw new ArgumentException("Cannot pass both a certificate and key");

            var jwtHandler = new JwtSecurityTokenHandler();
            var tokenDesc = new SecurityTokenDescriptor
            {
                SigningCredentials = signingCredentials,
                Subject = claims,
                NotBefore = DateTime.Now,
                Expires = tokenExpiry
            };

            var t = jwtHandler.CreateToken(tokenDesc);
            string token = jwtHandler.WriteToken(t);

            return token;
        }

        public X509Certificate2 LoadCertificate(string location, string certificatePassword = null)
        {
            if (!File.Exists(location))
                throw new ArgumentException("File not found for the given location");

            var certificate = new X509Certificate2(location, certificatePassword);

            if (certificate.NotAfter <= DateTime.Now)
                throw new InvalidOperationException("This certificate has expired. This will not used to sign requests. Please procure a new certificate");

            return certificate;
        }

        public bool VerifyPasswordHash(byte[] passwordHash)
        {
            byte[] hashedPwd;
            byte[] salt = Encoding.UTF8.GetBytes(Constants.PASSWORD_HASH_SALT);
            using (var rfc = new Rfc2898DeriveBytes(passwordHash, salt, Constants.PASSWORD_HASH_ITERATIONS))
            {
                hashedPwd = rfc.GetBytes(Constants.PASSWORD_HASH_LENGTH);
            }

            return hashedPwd.AreBytesEqual(passwordHash);
        }


        private byte[] SerializeObjectData<T>(T obj)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            Type objType = obj.GetType();
            var serializableAttr = objType.GetCustomAttribute<SerializableAttribute>(true);
            var dataContractAttr = objType.GetCustomAttribute<DataContractAttribute>(true);
            bool serializable = serializableAttr != null && dataContractAttr != null;
            if (!serializable)
                throw new InvalidOperationException("Object provided must be decorated with Serializable or DataContract attributes");

            using (var ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, obj);

                byte[] buffer = new byte[ms.Length];
                ms.Read(buffer, 0, buffer.Length);

                return buffer;
            }
        }

        private bool TryDeserializeObject<T>(byte[] decryptedData, out T obj)
        {
            bool canDeserialize = false;

            try
            {
                using (var ms = new MemoryStream(decryptedData))
                {
                    var formatter = new BinaryFormatter();
                    obj = (T)formatter.Deserialize(ms);

                    canDeserialize = true;
                }
            }
            catch
            {
                obj = default(T);
                canDeserialize = false;
            }

            return canDeserialize;
        }
    }
}