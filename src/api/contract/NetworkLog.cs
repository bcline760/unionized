using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Unionized.Contract
{
    [DataContract]
    public class NetworkLog : UnionizedEntity
    {
        [DataMember]
        public DateTime LogDate { get; set; }

        [DataMember]
        public string Rule { get; set; }

        [DataMember]
        public string InterfaceIn { get; set; }

        [DataMember]
        public string InterfaceOut { get; set; }

        [DataMember]
        public string MacAddress { get; set; }

        [DataMember]
        public string SourceAddress { get; set; }

        [DataMember]
        public string DestinationAddress { get; set; }

        [DataMember]
        public int PacketLength { get; set; }

        [DataMember]
        public int TimeToLive { get; set; }

        [DataMember]
        public string Protocol { get; set; }

        [DataMember]
        public int? SourcePort { get; set; }

        [DataMember]
        public int? DestinationPort { get; set; }

        [DataMember]
        public string TcpAction { get; set; }

        [DataMember]
        public int? IcmpSequence { get; set; }
    }
}
