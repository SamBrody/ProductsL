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
        public DbSet<Producer> Producers { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Products.db");
            //optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producer>().HasMany(p => p.Product).WithOne(b => b.Producer).HasForeignKey(p => p.ProdId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Currency>().HasMany(p => p.Product).WithOne(b => b.Currency).HasForeignKey(p => p.CurrId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>().HasOne(p => p.Producer).WithMany(b => b.Product).HasForeignKey(p => p.ProdId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Product>().HasOne(p => p.Currency).WithMany(b => b.Product).HasForeignKey(p => p.CurrId).OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Producer>().HasData(
            new Producer[]
            {
                new Producer { Id=1, Name="Adidas", CityL="Herzogenaurach"},
                new Producer { Id=2, Name="Nike", CityL="Beaverton"},
                new Producer { Id=3, Name="Puma", CityL="Herzogenaurach"}
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
                new Product { Id=1, Name="A1", Description="fast&furios",ProdId=1, Price=100,CurrId=2,Available=true},
                new Product { Id=2, Name="B1", Description="soft",ProdId=3, Price=150,CurrId=2,Available=false},
                new Product { Id=3, Name="C1", Description="-",ProdId=2, Price=6000,CurrId=1,Available=true}
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}