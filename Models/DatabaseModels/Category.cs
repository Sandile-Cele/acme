using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ACME.Models.DatabaseModels
{
    [Table("category")]
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        [Column("categoryId")]
        public int CategoryId { get; set; }
        [Required]
        [Column("categoryName")]
        [StringLength(255)]
        public string CategoryName { get; set; }
        [Column("categoryDescription")]
        [StringLength(255)]
        public string CategoryDescription { get; set; }
        [Column("categoryImageUrl")]
        public string CategoryImageUrl { get; set; }

        [InverseProperty(nameof(Product.Category))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
