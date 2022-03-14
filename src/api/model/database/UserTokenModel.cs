
using System;
using MongoDB.Bson.Serialization.Attributes;

namespace Unionized.Model.Database
{
    public sealed class UserTokenModel : UnionizedModel
    {
        [BsonElement("token"), BsonRequired]
        public string TokenString { get; set; }

        [BsonElement("expiry"), BsonRequired]
        public DateTime TokenExpiry { get; set; }

        [BsonElement("genBy"), BsonRequired]
        public string GeneratedBy { get; set; }
    }
}
