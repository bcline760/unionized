using System;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Unionized.Model.Database
{
    [BsonIgnoreExtraElements, BsonDiscriminator(RootClass = true)]
    [BsonKnownTypes(typeof(NetworkLogModel), typeof(MonitoredServersModel))]
    public abstract class UnionizedModel
    {
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonIgnoreIfDefault, BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }

        [BsonElement("slug"), BsonRequired]
        public string Slug { get; set; }

        [BsonElement("created_at"), BsonRequired, BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime CreatedAt { get; set; }

        [BsonElement("updated_at"), BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
        public DateTime? UpdatedAt { get; set; }

        [BsonElement("active"), BsonRequired]
        public bool Active { get; set; }
    }
}
