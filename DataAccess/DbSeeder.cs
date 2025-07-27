// DataAccess/DbSeeder.cs
using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataAccess
{
    public static class DbSeeder
    {
        public static void Reseed(ApplicationDbContext context)
        {
            // Only run in development
            if (!context.Database.IsSqlServer() || !context.Database.IsRelational())
                return;

            if (context.Database.CanConnect())
            {
                try
                {
                    context.Database.ExecuteSqlRaw("DELETE FROM Products");
                    context.Database.ExecuteSqlRaw("DELETE FROM Categories");
                    context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Products', RESEED, 0)");
                    context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Categories', RESEED, 0)");
                }
                catch (Exception ex)
                {
                    // Log the error (you can use a logging framework here)
                    Console.WriteLine($"Error during database reseeding: {ex.Message}");
                    return; // Exit if there's an error
                }

                // Re-insert categories
                var categories = new List<Category>
            {
                new Category { catName = "Fiction", catOrder = 1, markedAsDeleted = false },
                new Category { catName = "Science", catOrder = 2, markedAsDeleted = false }
            };
                context.Categories.AddRange(categories);
                context.SaveChanges();

                // Re-insert products
                var products = new List<Product>
            {
                new Product { Title = "1984", Description = "Dystopian novel", Author = "George Orwell", Price = 49.99, CategoryId = 1 },
                new Product { Title = "The Martian", Description = "Sci-fi survival story", Author = "Andy Weir", Price = 59.99, CategoryId = 2 },
                new Product { Title = "Brave New World", Description = "Classic dystopia", Author = "Aldous Huxley", Price = 39.99, CategoryId = 1 }
            };
                context.Products.AddRange(products);
                context.SaveChanges();
            }
        }
    }
}
