using System;
using System.Collections.Generic;
using System.Text;

namespace Unionized.Contract
{
    public class AppRole
    {
        public int ID { get; set; }

        public string AdGroup { get; set; }

        public RoleType Role { get; set; }
    }
}
