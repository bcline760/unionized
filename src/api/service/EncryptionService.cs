using System;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

using Unionized.Interface.Service;
using Microsoft.IdentityModel.Tokens;

namespace Unionized.Service
{
    public class EncryptionService : IEncryptionService
    {
        public UnionizedConfiguration Configuration { get; private set; }
        public EncryptionService(UnionizedConfiguration config)
        {
            Configuration = config;
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

        public string Hash(string content)
        {
            if (content == null)
                throw new ArgumentNullException(nameof(content));

            byte[] buffer = Encoding.Default.GetBytes(content);
            byte[] hashedBuffer = null;
            using (SHA256 s256 = SHA256.Create())
            {
                hashedBuffer = s256.ComputeHash(buffer);
            }

            var sb = new StringBuilder();
            for (int i = 0; i < hashedBuffer.Length; i++)
            {
                sb.Append($"{hashedBuffer[i]:X2}");
            }

            return sb.ToString();
        }

        public string GenerateJwt(ClaimsIdentity claims, DateTime tokenExpiry, string issuer, string audience)
        {
            byte[] key = LoadEncryptionKey();
            var ssk = new SymmetricSecurityKey(key);
            var signingCredentials = new SigningCredentials(ssk, SecurityAlgorithms.HmacSha256Signature);

            var jwtHandler = new JwtSecurityTokenHandler();
            var tokenDesc = new SecurityTokenDescriptor
            {
                SigningCredentials = signingCredentials,
                Subject = claims,
                NotBefore = DateTime.Now,
                Expires = tokenExpiry,
                Issuer = issuer,
                Audience = audience
            };

            var t = jwtHandler.CreateToken(tokenDesc);
            string token = jwtHandler.WriteToken(t);

            return token;
        }

        public ClaimsPrincipal ValidateJwt(string token, string issuer, string audience)
        {
            byte[] key = LoadEncryptionKey();
            var ssk = new SymmetricSecurityKey(key);
            var signingCredentials = new SigningCredentials(ssk, SecurityAlgorithms.HmacSha256Signature);

            var handler = new JwtSecurityTokenHandler();
            var validationParams = new TokenValidationParameters
            {
                RequireSignedTokens = true,
                RequireExpirationTime = true,
                RequireAudience = true,
                ValidateTokenReplay = true,
                ValidateAudience = true,
                ValidateIssuer = true,
                ValidAudience = audience,
                ValidIssuer = issuer,
                IssuerSigningKey = signingCredentials.Key
            };

            try
            {
                SecurityToken validatedToken;
                var claims = handler.ValidateToken(token, validationParams, out validatedToken);

                return claims;
            }
            catch (SecurityTokenInvalidAudienceException invalidAudience) { } //Leaving these for future logging
            catch (SecurityTokenInvalidIssuerException invalidIssuer) { }
            catch (SecurityTokenInvalidSignatureException invalidSignature) { }
            catch (SecurityTokenReplayDetectedException replayDetected) { }
            catch (SecurityTokenExpiredException expiredToken) { }

            return null;
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

        private byte[] LoadEncryptionKey()
        {
            byte[] encryptionKey = null;
            string path = $"{Environment.CurrentDirectory}/unionized.key";
            if (File.Exists("unionized.key"))
            {
                using (FileStream fs = File.OpenRead(path))
                {
                    encryptionKey = new byte[fs.Length];
                    int bytesRead = fs.Read(encryptionKey);
                }
            }
            else
            {
                using (RSA rsa = RSA.Create())
                {
                    encryptionKey = rsa.ExportRSAPrivateKey();

                    // Write the key to disk for future use.
                    using (FileStream fs = File.OpenWrite(path))
                    {
                        fs.Write(encryptionKey);
                    }
                }
            }

            return encryptionKey;
        }
    }
}