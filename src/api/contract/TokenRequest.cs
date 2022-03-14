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
        /// The ID of the 
        /// </summary>
        [DataMember]
        public string ActiveDirectoryId { get; set; }

        /// <summary>
        /// Get or set the token audience which restricts the token beyond the audience of the app
        /// </summary>
        [DataMember]
        public string Audience { get; set; }

        /// <summary>
        /// Get or set an e-mail address associated with the token
        /// </summary>
        [DataMember]
        public string Email { get; set; }

        /// <summary>
        /// Get or set the token's expiration date
        /// </summary>
        [DataMember]
        public DateTime Expiration { get; set; }

        /// <summary>
        /// Get or set the issuer of the token
        /// </summary>
        [DataMember]
        public string Issuer { get; set; }

        /// <summary>
        /// Get or set the name of the token
        /// </summary>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Get or set whether to set the token as persistent
        /// </summary>
        [DataMember]
        public bool Persist { get; set; }

        /// <summary>
        /// Get or set the token's role
        /// </summary>
        public RoleType Role { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Username { get; set; }        
    }
}
