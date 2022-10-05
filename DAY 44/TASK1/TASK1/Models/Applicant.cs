using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TASK1.Models
{
    public class Applicant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = "";
        [Required]
        [StringLength(50)]
        public string Gender { get; set; } = "";
        [Required]
        [Range(25,55, ErrorMessage ="Currently we have no positions vacant for your age")]
        [DisplayName("Age in Years")]
        public int Age { get; set; }

        [Required]
        [StringLength(50)]
        public string Qualification { get; set; } = "";
        [Required]
        [Range(1,25, ErrorMessage ="No positions vacant for your experience")]
        [DisplayName("Total Experience in years")]
        public int TotalExperience { get; set; }

        public virtual List<Experience> Experiences { get; set; } = new List<Experience>(); //will store the details of applicants experience 

        public string PhotoUrl { get; set; }
        [Required(ErrorMessage ="Please choose the profile photo")]
        [Display(Name ="Profile Photo")]
        [NotMapped]
        public IFormFile ProfilePhoto { get; set; }
    }
}
