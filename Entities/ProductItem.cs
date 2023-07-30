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
    public class ProductItem
    {
        //[Key]
        public int Id { get; set; }

        public string productName { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Stock { get; set; }

        //Cuando la relacion es de 1 a 1
        [ForeignKey("Supplier")]
        public int Id_supplier { get; set; }

        [JsonIgnore]
        public virtual Supplier Supplier { get; set; }

        [ForeignKey("Brand")]
        public int Id_brand { get; set; }
        [JsonIgnore]
        public virtual Brand Brand { get; set; }

    }
}
