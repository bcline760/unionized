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

        [DataMember]
        public string LogonToken { get; set; }

        [DataMember]
        public VerificationStatus Status { get; set; }
    }
}
