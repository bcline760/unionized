using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Unionized.Model.Database
{
    public class AppRoleModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column("ad_group")]
        public string AdGroup { get; set; }
        [Column("role")]
        public string Role { get; set; }
    }
}
