using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductMicroservice.Model;
using Microsoft.EntityFrameworkCore;


namespace ProductMicroservice.Context
{
    public class ProductContext:DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
           : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsbuilder)
        {
            optionsbuilder.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>().HasData(
                    new Product() { Id = 1, Price = 80000.00, Name = "Iphone", Description = "Some example text.", Image_Name = "1.jfif", Rating = 2 },
                    new Product() { Id = 2, Price = 2000.00, Name = "Bracelet", Description = "Some example text.", Image_Name = "1.jfif", Rating = 3 },
                    new Product() { Id = 3, Price = 40000.00, Name = "Oneplus8", Description = "Some example text.", Image_Name = "1.jfif", Rating = 3 },
                    new Product() { Id = 4, Price = 15000.00, Name = "Apple Watch", Description = "Some example text.", Image_Name = "1.jfif", Rating = 3 }

                );
        }
        public DbSet<Product> Products { get; set; }
    }
}
