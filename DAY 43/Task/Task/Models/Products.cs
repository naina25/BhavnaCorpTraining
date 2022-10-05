using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task.Models
{
    public partial class Products
    {
        [Key]
        public int Code { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Category { get; set; }
        public int? Cost { get; set; }
        public int? Price { get; set; }

        [ForeignKey(nameof(Category))]
        [InverseProperty(nameof(Categories.Products))]
        public virtual Categories CategoryNavigation { get; set; }
    }
}
