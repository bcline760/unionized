using MongoDB.Bson.Serialization.Attributes;

namespace Unionized.Model.Database
{
    public sealed class MonitoredServersModel : UnionizedModel
    {
        [BsonElement, BsonRequired]
        public string HostName { get; set; }

        [BsonElement, BsonRequired]
        public string IpAddress { get; set; }
    }
}
