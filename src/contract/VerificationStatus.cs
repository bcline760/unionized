using System;
using System.Runtime.Serialization;

namespace Unionized.Contract
{
    [DataContract]
    public enum VerificationStatus
    {
        /// <summary>
        /// The request successfully
        /// </summary>
        [EnumMember]
        Success=0,
        /// <summary>
        /// User failed to authenticate to the system
        /// </summary>
        [EnumMember]
        FailedAuthentication=1,
        /// <summary>
        /// User authenticated but has not registered
        /// </summary>
        [EnumMember]
        UserNotFound=2,
        /// <summary>
        /// User has already registered with the system
        /// </summary>
        [EnumMember]
        UserAlreadyExists=3,
        /// <summary>
        /// User was disabled by the system.
        /// </summary>
        [EnumMember]
        UserDisabled=4
    }
}
