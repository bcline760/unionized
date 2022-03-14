using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Unionized.Contract
{
    [DataContract]
    public enum RoleType
    {
        [EnumMember]
        Admin,
        [EnumMember]
        User,
        [EnumMember]
        Nobody
    }
}
