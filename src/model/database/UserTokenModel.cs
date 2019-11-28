
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Unionized.Model.Database
{
    [Table("user_token")]
    public class UserTokenModel : UnionizedModel
    {
        [Column("token"), Required]
        public string TokenString { get; set; }

        [Column("expiry"), Required]
        public DateTime TokenExpiry { get; set; }

        [Column("generated_by"), Required]
        public string GeneratedBy { get; set; }
    }
}
