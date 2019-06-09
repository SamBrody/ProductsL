using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Products.Models;

namespace Products
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductVM>();
            CreateMap<Producer, ProducerVM>();
            CreateMap<Currency, CurrencyVM>();
        }
    }
}