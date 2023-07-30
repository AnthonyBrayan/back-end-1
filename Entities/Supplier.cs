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
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_supplier { get; set; }
        public string name_supplier { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Relación con TypeUser (muchos a uno)
        [ForeignKey("TypeUsuario")]
        public int IdTypeUsuario { get; set; }
        [JsonIgnore]
        public virtual TypeUsuario TypeUsuario { get; set; }

        // Relación con productos (uno a muchos)
        public ICollection<ProductItem> Products { get; set; }
    }
}
