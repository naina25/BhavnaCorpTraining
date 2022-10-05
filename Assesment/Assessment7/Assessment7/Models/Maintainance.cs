using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assessment7.Models
{
    public partial class Maintainance
    {
        [Key]
        [Column("MID")]
        public int Mid { get; set; }
        [Column("Vehicle_number")]
        [StringLength(50)]
        public string VehicleNumber { get; set; }
        [StringLength(50)]
        public string DealerName { get; set; }
        [StringLength(50)]
        public string SparePart { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }
    }
}
