using System;

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Unionized.Model.Database
{
    [BsonIgnoreExtraElements, BsonDiscriminator(RootClass = true)]
    [BsonKnownTypes(typeof(NetworkLogModel), typeof(UserTokenModel), typeof(MonitoredServersModel))]
    public abstract class UnionizedModel
    {
        [BsonIgnoreIfDefault, BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string Id { get; set; }

        [BsonElement, BsonRequired]
        public string Slug { get; set; }

        [BsonElement, BsonRequired]
        public DateTime CreatedAt { get; set; }

        [BsonElement]
        public DateTime? UpdatedAt { get; set; }

        [BsonElement, BsonRequired]
        public bool Active { get; set; }
    }
}
