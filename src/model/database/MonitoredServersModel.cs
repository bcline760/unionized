using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Unionized.Model.Database
{
    [Table("monitored_servers")]
    public class MonitoredServersModel : UnionizedModel
    {
        [Column("hostname")]
        public string HostName { get; set; }

        [Column("ip_address")]
        public string IpAddress { get; set; }
    }
}
