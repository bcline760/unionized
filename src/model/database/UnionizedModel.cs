using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unionized.Model.Database
{
    public abstract class UnionizedModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        [Column("slug"), Required]
        public string Slug { get; set; }
        [Column("created_at"), Required]
        public DateTime CreatedAt { get; set; }
        [Column("updated_at")]
        public DateTime? UpdateAt { get; set; }
        [Column("active", TypeName = "bit"), Required]
        public bool Active { get; set; }
    }
}
