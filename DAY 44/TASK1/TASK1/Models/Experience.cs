using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TASK1.Models
{
    public class Experience
    {
        [Key]
        public int ExperienceId { get; set; }
        [ForeignKey("Applicant")]
        public int ApplicantId { get; set; }
        public virtual Applicant Applicant { get; private set; }
        public string companyName { get; set; }
        public string Designation { get; set; }
        [Required]
        public int YearsWorked { get; set; }
    }
    

}
