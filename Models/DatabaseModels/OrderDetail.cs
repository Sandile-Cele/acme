using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace ACME.Models.DatabaseModels
{
    [Table("orderDetails")]
    public partial class OrderDetail
    {
        [Key]
        [Column("orderDetailsId")]
        public int OrderDetailsId { get; set; }
        [Column("orderDetailsDatePlaced", TypeName = "date")]
        public DateTime OrderDetailsDatePlaced { get; set; }
        [Column("clientId")]
        public int ClientId { get; set; }
        [Column("productId")]
        public int ProductId { get; set; }
        [Column("orderDetailsFulfilled")]
        public bool OrderDetailsFulfilled { get; set; }

        [ForeignKey(nameof(ClientId))]
        [InverseProperty("OrderDetails")]
        public virtual Client Client { get; set; }
        [ForeignKey(nameof(ProductId))]
        [InverseProperty("OrderDetails")]
        public virtual Product Product { get; set; }
    }
}
