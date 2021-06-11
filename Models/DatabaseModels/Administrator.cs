using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ACME.Models.DatabaseModels
{
    [Table("administrator")]
    public partial class Administrator
    {
        [Key]
        [Column("administratorId")]
        public int AdministratorId { get; set; }
        [Column("administratorEmployeeNumber")]
        public int? AdministratorEmployeeNumber { get; set; }
        [Required]
        [Column("administratorUsername")]
        [StringLength(255)]
        public string AdministratorUsername { get; set; }
        [Required]
        [Column("administratorPassword")]
        [StringLength(255)]
        public string AdministratorPassword { get; set; }
    }
}
