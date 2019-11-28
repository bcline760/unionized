using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unionized.Model.Database
{
    [Table("network_log")]
    public class NetworkLogModel : UnionizedModel
    {
        [Column("log_date"), Required]
        public string LogDate { get; set; }

        [Column("rule"), Required]
        public string Rule { get; set; }

        [Column("iface_in"), Required]
        public string InterfaceIn { get; set; }

        [Column("iface_out"), Required]
        public string InterfaceOut { get; set; }

        [Column("mac_address"), Required]
        public string MacAddress { get; set; }

        [Column("src_address"), Required]
        public string SourceAddress { get; set; }

        [Column("dst_address"), Required]
        public string DestinationAddress { get; set; }

        [Column("packet_len"), Required]
        public int PacketLength { get; set; }

        [Column("ttl"), Required]
        public int TimeToLive { get; set; }

        [Column("protocol"), Required]
        public string Protocol { get; set; }

        [Column("src_port")]
        public int? SourcePort { get; set; }

        [Column("dst_port")]
        public int? DestinationPort { get; set; }

        [Column("tcp_action")]
        public string TcpAction { get; set; }

        [Column("icmp_seq")]
        public int? IcmpSequence { get; set; }
    }
}
