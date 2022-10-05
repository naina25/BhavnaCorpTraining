using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assessment7.Models
{
    [Table("managers")]
    public partial class Managers
    {
        [Key]
        [Column("manager_id")]
        public int ManagerId { get; set; }
        [Column("department")]
        [StringLength(50)]
        public string Department { get; set; }
        [Column("name")]
        [StringLength(50)]
        public string Name { get; set; }
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
    }
}
