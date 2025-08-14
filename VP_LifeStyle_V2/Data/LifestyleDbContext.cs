using Microsoft.EntityFrameworkCore;
using System;
using VP_Lifestyle.Models;
using VP_LifeStyle_V2.Models;

namespace VP_Lifestyle.Data
{
    public class LifestyleDbContext:DbContext
    {
        public LifestyleDbContext(DbContextOptions<LifestyleDbContext> options) : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }   
        //Always add a Dbset for a class that will be used.
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        //Adding  database table, managing data

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Reservation>().ToTable("Reservation");
          
        }
    }
}
