using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Products.Models.PostRM
{
    public class ProductPostRM
    {
        [Required(AllowEmptyStrings =false)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(1, 99999999)]
        public int Price { get; set; }

        [Required]
        public int ManufacturerID { get; set; }
        [Required]
        public int CurrencyID { get; set; }
    }
}