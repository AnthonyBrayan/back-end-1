using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_order { get; set; }
        public DateTime FechaPedido { get; set; }
        public DateTime FechaEntrega { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Totalamount { get; set; }
        public string Order_status { get; set; }

        // Relación con cliente (muchos a uno)
        [ForeignKey("Custumer")]
        public int IdCustomer { get; set; }
        [JsonIgnore]
        public virtual Customer Custumer { get; set; }

        // Relación con detalles de pedido (uno a muchos)
        public ICollection<Order_detail> order_Detail { get; set; }
    }
}
