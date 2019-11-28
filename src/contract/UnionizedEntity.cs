using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Unionized.Contract
{
    [KnownType(typeof(UserToken)),
        KnownType(typeof(NetworkLog))]
    public abstract class UnionizedEntity : ISluggable
    {
        /// <summary>
        /// The Prim
        /// </summary>
        [IgnoreDataMember]
        public Guid ID { get; set; }

        [DataMember]
        public string Slug { get; set; }

        /// <summary>
        /// Get or set when the object was created in the data store
        /// </summary>
        /// <value>The created at.</value>
        [DataMember]
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// Get or set when the object was last modified
        /// </summary>
        /// <value>The updated at.</value>
        [DataMember]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:Unionized.Contract.UnionizedEntity"/> is active.
        /// </summary>
        /// <value><c>true</c> if is active; otherwise, <c>false</c>.</value>
        [DataMember]
        public bool Active { get; set; }

        [IgnoreDataMember]
        public virtual string[] SlugProperties
        {
            get
            {
                return new string[] {
                    CreatedAt.Ticks.ToString().FirstEight()
                };
            }
        }
    }
}
