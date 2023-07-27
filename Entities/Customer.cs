using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_customer { get; set; }
        public string Name_customer { get; set; }
        public string Email { get; set; }

        // Relación con pedidos (uno a muchos)
        public ICollection<Order> orders { get; set; }
    }
}
