using MongoDB.Bson.Serialization.Attributes;

namespace Unionized.Model.Database
{
    public sealed class MonitoredServersModel : UnionizedModel
    {
        [BsonElement("host"), BsonRequired]
        public string HostName { get; set; }

        [BsonElement("ipAddr"), BsonRequired]
        public string IpAddress { get; set; }
    }
}
