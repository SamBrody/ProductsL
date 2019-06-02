﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Products.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int PrId { get; set; }
        public virtual Producer Producer { get; set; }
        public int Price { get; set; }
        public int CurId { get; set; }
        public virtual Currency Currency { get; set; }
        public bool Available { get; set; }
    }
}
