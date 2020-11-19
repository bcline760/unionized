using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Unionized.Contract
{
    [DataContract]
    public class MonitoredServer : UnionizedEntity
    {
        [DataMember]
        public string HostName { get; set; }

        [DataMember]
        public string IpAddress { get; set; }

        [DataMember]
        public bool Online { get; set; }
    }
}
