using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Products.Models
{
    public class ProductRM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public bool Available { get; set; }
        public string ManufacturerName { get; set; }
        public string CurrencyName { get; set; }
    }
}