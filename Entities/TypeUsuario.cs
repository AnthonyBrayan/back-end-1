using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class TypeUsuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_TypeUser { get; set; }
        public string TypeUser_name { get; set; }

        // Relación con Custumer (uno a muchos)
        public ICollection<Customer> Customer { get; set; }

        // Relación con Supplier (uno a muchos)
        public ICollection<Supplier> Supplier { get; set; }
    }
}
