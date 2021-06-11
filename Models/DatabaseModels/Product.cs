using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ACME.Models.DatabaseModels
{
    [Table("product")]
    public partial class Product
    {
        [Key]
        [Column("productId")]
        public int ProductId { get; set; }
        [Required]
        [Column("productName")]
        [StringLength(255)]
        public string ProductName { get; set; }
        [Column("productMsrp", TypeName = "decimal(19, 4)")]
        public decimal? ProductMsrp { get; set; }
        [Column("productPrice", TypeName = "decimal(19, 4)")]
        public decimal ProductPrice { get; set; }
        [Column("categoryId")]
        public int? CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [InverseProperty("Products")]
        public virtual Category Category { get; set; }
    }
}
