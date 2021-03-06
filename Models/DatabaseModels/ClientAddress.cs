using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ACME.Models.DatabaseModels
{
    [Table("clientAddress")]
    public partial class ClientAddress
    {
        [Key]
        [Column("clientAddressId")]
        public int ClientAddressId { get; set; }
        [Column("clientId")]
        public int? ClientId { get; set; }
        [Column("clientAddressAddressLine1")]
        [StringLength(255)]
        public string ClientAddressAddressLine1 { get; set; }
        [Column("clientAddressAddressLine2")]
        [StringLength(255)]
        public string ClientAddressAddressLine2 { get; set; }
        [Column("clientAddressAddressLine3")]
        [StringLength(255)]
        public string ClientAddressAddressLine3 { get; set; }
        [Column("clientAddressAddressLine4")]
        [StringLength(255)]
        public string ClientAddressAddressLine4 { get; set; }
        [Required]
        [Column("clientAddressPostalCode")]
        [StringLength(255)]
        public string ClientAddressPostalCode { get; set; }

        [ForeignKey(nameof(ClientId))]
        [InverseProperty("ClientAddresses")]
        public virtual Client Client { get; set; }
    }
}
