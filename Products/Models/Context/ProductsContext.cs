using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using Products.Models;


namespace Products.Models
{
    public class ProductsContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Products.db");
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacturer>().HasMany(p => p.Product).WithOne(b => b.Manufacturer).HasForeignKey(p => p.ManufacturerID).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Currency>().HasMany(p => p.Product).WithOne(b => b.Currency).HasForeignKey(p => p.CurrencyID).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>().HasOne(p => p.Manufacturer).WithMany(b => b.Product).HasForeignKey(p => p.ManufacturerID).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Product>().HasOne(p => p.Currency).WithMany(b => b.Product).HasForeignKey(p => p.CurrencyID).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Manufacturer>().HasData(
            new Manufacturer[]
            {
                new Manufacturer { Id=1, Name="Adidas", CityL="Herzogenaurach"},
                new Manufacturer { Id=2, Name="Nike", CityL="Beaverton"},
                new Manufacturer { Id=3, Name="Puma", CityL="Herzogenaurach"}
            });       
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Currency>().HasData(
            new Currency[]
            {
                new Currency { Id=1, Name="₽"},
                new Currency { Id=2, Name="$"},
            });
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
            new Product[]
            {
                new Product { Id=1, Name="A1", Description="fast&furios",ManufacturerID=1, Price=100,CurrencyID=2,Available=true},
                new Product { Id=2, Name="B1", Description="soft",ManufacturerID=3, Price=150,CurrencyID=2,Available=false},
                new Product { Id=3, Name="C1", Description="-",ManufacturerID=2, Price=6000,CurrencyID=1,Available=true}
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}