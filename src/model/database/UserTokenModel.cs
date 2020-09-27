
using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Unionized.Model.Database
{
    public sealed class UserTokenModel : UnionizedModel
    {
        [BsonElement, BsonRequired]
        public string TokenString { get; set; }

        [BsonElement, BsonRequired]
        public DateTime TokenExpiry { get; set; }

        [BsonElement, BsonRequired]
        public string GeneratedBy { get; set; }
    }
}
