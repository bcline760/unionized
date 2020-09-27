using System;

using MongoDB.Bson.Serialization.Attributes;

namespace Unionized.Model.Database
{
    public class NetworkLogModel : UnionizedModel
    {
        [BsonElement, BsonRequired]
        public DateTime LogDate { get; set; }

        [BsonElement, BsonRequired]
        public string Rule { get; set; }

        [BsonElement]
        public string InterfaceIn { get; set; }

        [BsonElement]
        public string InterfaceOut { get; set; }

        [BsonElement, BsonRequired]
        public string MacAddress { get; set; }

        [BsonElement, BsonRequired]
        public string SourceAddress { get; set; }

        [BsonElement, BsonRequired]
        public string DestinationAddress { get; set; }

        [BsonElement, BsonRequired]
        public int PacketLength { get; set; }

        [BsonElement, BsonRequired]
        public int TimeToLive { get; set; }

        [BsonElement, BsonRequired]
        public string Protocol { get; set; }

        [BsonElement]
        public int? SourcePort { get; set; }

        [BsonElement]
        public int? DestinationPort { get; set; }

        [BsonElement]
        public string TcpAction { get; set; }

        [BsonElement]
        public int? IcmpSequence { get; set; }
    }
}
