using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Products = new HashSet<Products>();
        }

        [Key]
        [StringLength(50)]
        public string CtCode { get; set; }
        [StringLength(50)]
        public string CatName { get; set; }

        [InverseProperty("CategoryNavigation")]
        public virtual ICollection<Products> Products { get; set; }
    }
}
