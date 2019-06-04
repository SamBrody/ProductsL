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
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Producer)
                .WithMany(b => b.Product);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Currency)
                .WithMany(b => b.Product);

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
                new Product { Id=1, Name="A1", Description="fast&furios", Price=100,Available=true},
                new Product { Id=2, Name="B1", Description="soft", Price=150,Available=false},
                new Product { Id=3, Name="C1", Description="-", Price=6000,Available=true}
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}