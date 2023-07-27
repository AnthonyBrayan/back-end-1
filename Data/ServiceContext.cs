﻿using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Runtime;

namespace Data
{
    public class ServiceContext : DbContext
    {
        public ServiceContext(DbContextOptions<ServiceContext> options) : base(options) { }
        public DbSet<ProductItem> Products { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Order_detail> Order_detail { get; set; }
        public DbSet<Supplier> Supllier { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProductItem>(entity =>
            {
                entity.ToTable("Products");
            });

            builder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");
            });

            builder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");
            });
            builder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");
            });
            builder.Entity<Order_detail>(entity =>
            {
                entity.ToTable("Order_detail");
            });
            builder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Supplier");
            });

        }
    }
    public class ServiceContextFactory : IDesignTimeDbContextFactory<ServiceContext>
    {
        public ServiceContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json", false, true);
            var config = builder.Build();
            var connectionString = config.GetConnectionString("ServiceContext");
            var optionsBuilder = new DbContextOptionsBuilder<ServiceContext>();
            optionsBuilder.UseSqlServer(config.GetConnectionString("ServiceContext"));

            return new ServiceContext(optionsBuilder.Options);
        }
    }
}