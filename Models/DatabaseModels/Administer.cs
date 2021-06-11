using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ACME.Models.DatabaseModels
{
    [Table("administer")]
    public partial class Administer
    {
        [Key]
        [Column("administerId")]
        public int AdministerId { get; set; }
        [Column("administerEmployeeNumber")]
        public int? AdministerEmployeeNumber { get; set; }
        [Required]
        [Column("administerUsername")]
        [StringLength(255)]
        public string AdministerUsername { get; set; }
        [Required]
        [Column("administerPassword")]
        [StringLength(255)]
        public string AdministerPassword { get; set; }
    }
}
