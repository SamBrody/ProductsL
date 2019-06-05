using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Products.Models
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool Available { get; set; }

        
        public virtual ProducerVM Producer { get; set; }
        public virtual CurrencyVM Currency { get; set; }
    }
}