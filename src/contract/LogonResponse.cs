using System;
using System.Runtime.Serialization;

namespace Unionized.Contract
{
    [DataContract]
    public class LogonResponse
    {
        public LogonResponse()
        {
        }

        /// <summary>
        /// Get or set the authenticated user's e-mail address
        /// </summary>
        [DataMember]
        public string Email { get; set; }

        /// <summary>
        /// Get or set the authenticated user's first name
        /// </summary>
        [DataMember]
        public string FirstName { get; set; }

        /// <summary>
        /// Get or set the authenticated user's last name
        /// </summary>
        [DataMember]
        public string LastName { get; set; }

        /// <summary>
        /// Get or set the logon JWT
        /// </summary>
        [DataMember]
        public string LogonToken { get; set; }

        /// <summary>
        /// The authenticated user's role
        /// </summary>
        [DataMember]
        public RoleType Role { get; set; }

        /// <summary>
        /// Get or set the authentication request status
        /// </summary>
        [DataMember]
        public VerificationStatus Status { get; set; }

        /// <summary>
        /// Get or set the username trying to authenticate
        /// </summary>
        [DataMember]
        public string Username { get; set; }
    }
}
