using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Unionized.Contract
{
    [DataContract]
    public class TokenRequest
    {
        /// <summary>
        /// Get or set an e-mail address associated with the token
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Get or set the token's expiration date
        /// </summary>
        public DateTime Expiration { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ObjectId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Persist { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RoleType Role { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Username { get; set; }
    }
}
