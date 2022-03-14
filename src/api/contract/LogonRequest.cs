using System;
using System.Runtime.Serialization;

namespace Unionized.Contract
{
    [DataContract]
    public class LogonRequest
    {
        public LogonRequest()
        {
        }

        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public bool Persist { get; set; }
        [DataMember]
        public string SsoToken { get; set; }
    }
}
