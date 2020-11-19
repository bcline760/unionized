using System;

using MongoDB.Bson.Serialization.Attributes;

namespace Unionized.Model.Database
{
    public class NetworkLogModel : UnionizedModel
    {
        [BsonElement("logDate"), BsonRequired]
        public DateTime LogDate { get; set; }

        [BsonElement("rule"), BsonRequired]
        public string Rule { get; set; }

        [BsonElement("ifaceIn")]
        public string InterfaceIn { get; set; }

        [BsonElement("ifaceOut")]
        public string InterfaceOut { get; set; }

        [BsonElement("macAddr"), BsonRequired]
        public string MacAddress { get; set; }

        [BsonElement("sAddr"), BsonRequired]
        public string SourceAddress { get; set; }

        [BsonElement("dAddr"), BsonRequired]
        public string DestinationAddress { get; set; }

        [BsonElement("pLen"), BsonRequired]
        public int PacketLength { get; set; }

        [BsonElement("ttl"), BsonRequired]
        public int TimeToLive { get; set; }

        [BsonElement("proto"), BsonRequired]
        public string Protocol { get; set; }

        [BsonElement("sPrt")]
        public int? SourcePort { get; set; }

        [BsonElement("dPrt")]
        public int? DestinationPort { get; set; }

        [BsonElement("tcp")]
        public string TcpAction { get; set; }

        [BsonElement("icmpSeq")]
        public int? IcmpSequence { get; set; }
    }
}
