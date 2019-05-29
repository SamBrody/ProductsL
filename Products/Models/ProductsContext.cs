using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;


namespace Products.Models
{
    public class ProductsContext : DbContext
    {
        public DbSet<Products> Products_ { get; set; }
        public DbSet<Currency> Currency_ { get; set; }
        public DbSet<Producer> Producer_ { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Products.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<Products>().HasData(
            new Products[]
            {
                new Products { Id=1, Name="A1", Description="fast&furios", PrId=3,Price=100,CurId=2,Available=true},
                new Products { Id=2, Name="B1", Description="soft", PrId=2,Price=150,CurId=2,Available=false},
                new Products { Id=3, Name="C1", Description="-", PrId=1,Price=6000,CurId=1,Available=true}
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}