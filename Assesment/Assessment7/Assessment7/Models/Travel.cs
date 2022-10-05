using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assessment7.Models
{
    public partial class Travel
    {
        [Key]
        [Column("Route_id")]
        [StringLength(50)]
        public string RouteId { get; set; }
        [Required]
        [Column("Vehicle_number")]
        [StringLength(50)]
        public string VehicleNumber { get; set; }
        [StringLength(50)]
        public string Pickup { get; set; }
        [StringLength(50)]
        public string Destination { get; set; }
        [Column("Passenger_name")]
        [StringLength(50)]
        public string PassengerName { get; set; }
        public int? Amount { get; set; }
    }
}
