using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

[assembly: OwinStartup(typeof(Products.Startup))]

namespace Products
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc();
        }

        public void Configuration(IAppBuilder app)
        {
        }
    }
}
