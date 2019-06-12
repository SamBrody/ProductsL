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
            CreateMap<Product, ProductRM>();
            CreateMap<Producer, ProducerRM>();
            CreateMap<Currency, CurrencyRM>();
            CreateMap<Producer, ProductRM>()
                .ForMember(x => x.Producer_Name, x => x.MapFrom(m => m.Name));
            CreateMap<Currency, ProductRM>()
                .ForMember(x => x.Currency_Name, x => x.MapFrom(m => m.Name));
        }
    }
}