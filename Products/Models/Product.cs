using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Products.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }     
        public int Price { get; set; }
        public bool Available { get; set; }

        public int ManufacturerID { get; set; }
        public int CurrencyID { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }
        public virtual Currency Currency { get; set; }
    }
}
