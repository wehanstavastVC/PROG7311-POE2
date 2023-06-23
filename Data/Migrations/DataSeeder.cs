using FarmerCentral2.Models;
using System.Linq;

namespace FarmerCentral2.Data.Migrations
{
    public class DataSeeder
    {
        private readonly ApplicationDbContext _dbContext;
        public DataSeeder(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Seed Data Concept
        public void SeedData()
        {

            if (!_dbContext.Products.Any())
            {
                // Inserting pre-populated data for Products
                var products = new List<Product>
            {
                new Product
                {
                    ProductId = 1,
                    ProductName = "White Bread",
                    Type = "Food",
                    Date = DateTime.Today,
                    ApplicationUserId = "356d06e9-7f94-47a3-9a60-cc59415628a8"
                },
                new Product
                {
                    ProductId = 2,
                    ProductName = "Apple",
                    Type = "Food",
                    Date = DateTime.Today,
                    ApplicationUserId = "356d06e9-7f94-47a3-9a60-cc59415628a8"
                },
                new Product
                {
                    ProductId = 3,
                    ProductName = "Milk",
                    Type = "Dairy",
                    Date = DateTime.Today,
                    ApplicationUserId = "356d06e9-7f94-47a3-9a60-cc59415628a8"
                },
                new Product
                {
                    ProductId = 4,
                    ProductName = "Chicken Eggs",
                    Type = "Food",
                    Date = DateTime.Today,
                    ApplicationUserId = "8f6d6f33-ac23-4a92-8790-e5d26bb4beb0"
                },
                new Product
                {
                    ProductId = 5,
                    ProductName = "Onion",
                    Type = "Food",
                    Date = DateTime.Today,
                    ApplicationUserId = "8f6d6f33-ac23-4a92-8790-e5d26bb4beb0"
                },
                new Product
                {
                    ProductId = 6,
                    ProductName = "Chicken Meat",
                    Type = "Food",
                    Date = DateTime.Today,
                    ApplicationUserId = "8f6d6f33-ac23-4a92-8790-e5d26bb4beb0"
                },
                new Product
                {
                    ProductId = 7,
                    ProductName = "Cow Meat",
                    Type = "Food",
                    Date = DateTime.Today,
                    ApplicationUserId = "86a36866-e9e8-437c-9033-a1ffc44c37c0"
                },
                new Product
                {
                    ProductId = 8,
                    ProductName = "Wine",
                    Type = "Alcohol",
                    Date = DateTime.Today,
                    ApplicationUserId = "86a36866-e9e8-437c-9033-a1ffc44c37c0"
                },
                new Product
                {
                    ProductId = 9,
                    ProductName = "Rice",
                    Type = "Cereal Grain",
                    Date = DateTime.Today,
                    ApplicationUserId = "86a36866-e9e8-437c-9033-a1ffc44c37c0"
                }
            };

             _dbContext.Products.AddRange(products);
             _dbContext.SaveChanges();
            }
        }
    }
}

