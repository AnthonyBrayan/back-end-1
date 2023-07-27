using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Order_detail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_order_detail { get; set; }
        public int Quantity { get; set; }

        // Relación con pedido (muchos a uno)
        [ForeignKey("Order")]
        public int IdOrder { get; set; }
        public virtual Order Order { get; set; }

        // Relación con producto (muchos a uno)
        [ForeignKey("Product")]
        public int IdProduct { get; set; }
        public virtual ProductItem Product { get; set; }
    }
}
