using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Products.Models;
using Products.Models.PostRM;

namespace Products
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductRM>();
            CreateMap<Currency, CurrencyRM>();
            CreateMap<Manufacturer, ProductRM>()
                .ForMember(x => x.ManufacturerName, x => x.MapFrom(m => m.Name));
            CreateMap<Currency, ProductRM>()
                .ForMember(x => x.CurrencyName, x => x.MapFrom(m => m.Name));
            CreateMap<ProductPostRM, Product>()
                .ForMember(pr => pr.Name, pr => pr.MapFrom(ppr => ppr.Name))
                .ForMember(pr => pr.Price, pr => pr.MapFrom(ppr => ppr.Price))
                .ForMember(pr => pr.ManufacturerID, pr => pr.MapFrom(ppr => ppr.ManufacturerID))
                .ForMember(pr => pr.CurrencyID, pr => pr.MapFrom(ppr => ppr.CurrencyID))
                .ForMember(pr => pr.Description, pr => pr.MapFrom(ppr => ppr.Description))
                .ForAllOtherMembers(pr => pr.Ignore());
            CreateMap<ManufacturerPostRM, Manufacturer>()
                .ForMember(m => m.Name, m => m.MapFrom(mpr => mpr.Name))
                .ForMember(m => m.CityL, m => m.MapFrom(mpr => mpr.CityL))
                .ForAllOtherMembers(m => m.Ignore()); 
            CreateMap<CurrencyPostRM, Currency>()
                .ForMember(c => c.Name, c => c.MapFrom(cpr => cpr.Name))
                .ForAllOtherMembers(c => c.Ignore()); 
        }
    }
}