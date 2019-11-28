using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Unionized.Contract
{
    [DataContract]
    public class UserToken : UnionizedEntity
    {
        [DataMember]
        public string TokenString { get; set; }

        [DataMember]
        public DateTime TokenExpiry { get; set; }
    }
}
