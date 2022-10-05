using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assessment7.Models
{
    [Table("login")]
    public partial class Login
    {
        [Key]
        [Column("log_id")]
        [StringLength(50)]
        public string LogId { get; set; }
        [Column("password")]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
