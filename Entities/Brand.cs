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
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_brand { get; set; }
        public string name_brand { get; set; }

        [JsonIgnore]

        // Relación con productos (uno a muchos)
        public ICollection<ProductItem> Products { get; set; }
    }
}
