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

        public int ProdId { get; set; }
        public int CurrId { get; set; }
        public virtual Producer Producer { get; set; }
        public virtual Currency Currency { get; set; }
    }
}
