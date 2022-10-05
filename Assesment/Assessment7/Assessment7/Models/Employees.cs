using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assessment7.Models
{
    public partial class Employees
    {
        [Key]
        [Column("Employee_id")]
        public int EmployeeId { get; set; }
        [Column("Emp_designation")]
        [StringLength(50)]
        public string EmpDesignation { get; set; }
        [Column("Emp_name")]
        [StringLength(50)]
        public string EmpName { get; set; }
        [Column("Emp_email")]
        [StringLength(50)]
        public string EmpEmail { get; set; }
        [Column("DOB")]
        [StringLength(50)]
        public string Dob { get; set; }
        [StringLength(50)]
        public string Gender { get; set; }
        [StringLength(50)]
        public string Address { get; set; }
        [Column("ImageURL")]
        [StringLength(500)]
        public string ImageUrl { get; set; }
    }
}
