using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ACME.Models.DatabaseModels
{
    [Table("client")]
    public partial class Client
    {
        public Client()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        [Key]
        [Column("clientId")]
        public int ClientId { get; set; }
        [Required]
        [Column("clientName")]
        [StringLength(255)]
        public string ClientName { get; set; }
        [Required]
        [Column("clientSurname")]
        [StringLength(255)]
        public string ClientSurname { get; set; }
        [Required]
        [Column("clientEmail")]
        [StringLength(255)]
        public string ClientEmail { get; set; }
        [Required]
        [Column("clientPassword")]
        [StringLength(255)]
        public string ClientPassword { get; set; }
        [Column("clientAddressId")]
        public int? ClientAddressId { get; set; }

        [ForeignKey(nameof(ClientAddressId))]
        [InverseProperty("Clients")]
        public virtual ClientAddress ClientAddress { get; set; }
        [InverseProperty(nameof(OrderDetail.Client))]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
