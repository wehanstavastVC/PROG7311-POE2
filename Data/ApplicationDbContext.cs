using FarmerCentral2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FarmerCentral2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Creating Products
            var p1 = new Product 
            { 
                ProductId = 1,
                ProductName = "White Bread",
                Type = "Food",
                Date = DateTime.Today,
                ApplicationUserId = "356d06e9-7f94-47a3-9a60-cc59415628a8" //farmer
            };
            // Seeding Products
            builder.Entity<Product>().HasData(p1);

            var p2 = new Product
            {
                ProductId = 2,
                ProductName = "Apple",
                Type = "Food",
                Date = DateTime.Today,
                ApplicationUserId = "356d06e9-7f94-47a3-9a60-cc59415628a8" //farmer
            };
            builder.Entity<Product>().HasData(p2);

            var p3 = new Product
            {
                ProductId = 3,
                ProductName = "Milk",
                Type = "Dairy",
                Date = DateTime.Today,
                ApplicationUserId = "356d06e9-7f94-47a3-9a60-cc59415628a8" //farmer
            };
            builder.Entity<Product>().HasData(p3);

            var p4 = new Product
            {
                ProductId = 4,
                ProductName = "Chicken Eggs",
                Type = "Food",
                Date = DateTime.Today,
                ApplicationUserId = "8f6d6f33-ac23-4a92-8790-e5d26bb4beb0" //farmer1
            };
            builder.Entity<Product>().HasData(p4);

            var p5 = new Product
            {
                ProductId = 5,
                ProductName = "Onion",
                Type = "Food",
                Date = DateTime.Today,
                ApplicationUserId = "8f6d6f33-ac23-4a92-8790-e5d26bb4beb0" //farmer1
            };
            builder.Entity<Product>().HasData(p5);

            var p6 = new Product
            {
                ProductId = 6,
                ProductName = "Chicken Meat",
                Type = "Food",
                Date = DateTime.Today,
                ApplicationUserId = "8f6d6f33-ac23-4a92-8790-e5d26bb4beb0" //farmer1
            };
            builder.Entity<Product>().HasData(p6);

            var p7 = new Product
            {
                ProductId = 7,
                ProductName = "Cow Meat",
                Type = "Food",
                Date = DateTime.Today,
                ApplicationUserId = "86a36866-e9e8-437c-9033-a1ffc44c37c0" //farmer2
            };
            builder.Entity<Product>().HasData(p7);

            var p8 = new Product
            {
                ProductId = 8,
                ProductName = "Wine",
                Type = "Alcohol",
                Date = DateTime.Today,
                ApplicationUserId = "86a36866-e9e8-437c-9033-a1ffc44c37c0" //farmer2
            };
            builder.Entity<Product>().HasData(p8);

            var p9 = new Product
            {
                ProductId = 9,
                ProductName = "Rice",
                Type = "Cereal Grain",
                Date = DateTime.Today,
                ApplicationUserId = "86a36866-e9e8-437c-9033-a1ffc44c37c0" //farmer2
            };
            builder.Entity<Product>().HasData(p9);
        }
    }
}