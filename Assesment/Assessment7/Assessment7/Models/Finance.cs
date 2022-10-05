using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assessment7.Models
{
    public partial class Finance
    {
        [Key]
        [Column("Transaction_id")]
        public int TransactionId { get; set; }
        [Column("Vehicle_number")]
        [StringLength(50)]
        public string VehicleNumber { get; set; }
        [Column("Vehicle_name")]
        [StringLength(50)]
        public string VehicleName { get; set; }
        [Column("Passenger_name")]
        [StringLength(50)]
        public string PassengerName { get; set; }
        public int? Amount { get; set; }
        [Column("Payment_mode")]
        [StringLength(50)]
        public string PaymentMode { get; set; }
        [Column("Billing_date", TypeName = "date")]
        public DateTime? BillingDate { get; set; }
    }
}
