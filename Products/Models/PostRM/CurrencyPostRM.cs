using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Products.Models.PostRM
{
    public class CurrencyPostRM
    {
        [Required(AllowEmptyStrings =false)]
        public string Name { get; set; }       
    }
}