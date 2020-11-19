using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Unionized.Contract
{
    [DataContract]
    public class LogoutRequest
    {
        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Token { get; set; }
    }
}
