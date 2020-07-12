using System;
using System.Runtime.Serialization;

namespace Unionized.Contract
{
    [DataContract]
    public class EntityState
    {
        public EntityState()
        {
        }

        [DataMember]
        public EntityAttributes Attributes { get; set; }
        [DataMember]
        public string EntityId { get; set; }
        [DataMember]
        public DateTimeOffset LastChanged { get; set; }
        [DataMember]
        public DateTimeOffset LastUpdated { get; set; }
        [DataMember]
        public string State { get; set; }
    }
}
