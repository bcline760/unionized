using System;
namespace Unionized
{
    public static class Constants
    {
        /// <summary>
        /// A key size of 1,024 bits
        /// </summary>
        public static readonly int KEY_SIZE_SMALL = 1024;
        /// <summary>
        /// A key size of 2,048 bits
        /// </summary>
        public static readonly int KEY_SIZE_MEDIUM = 2048;

        /// <summary>
        /// A key size of 4,096 bits
        /// </summary>
        public static readonly int KEY_SIZE_LARGE = 4096;
        /// <summary>
        /// The number of iterations to use for password hashing. More = secure, but more = slower
        /// </summary>
        public static readonly int PASSWORD_HASH_ITERATIONS = 4096;
        /// <summary>
        /// Number of bytes to use for password hashes
        /// </summary>
        public static readonly int PASSWORD_HASH_LENGTH = 16;
        /// <summary>
        /// The salt used for password hashing.
        /// </summary>
        public static string PASSWORD_HASH_SALT = "jCRB2r#r5-K@#%PqBHnL73mRP?^eGb*cT8=d7-bAMD4z8%Fb";
    }
}
