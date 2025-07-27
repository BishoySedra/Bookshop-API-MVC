using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataAccess.SeedData
{
    public static class ProductSeedData
    {
        public static void SeedProducts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Title = "1984", Description = "Dystopian novel", Author = "George Orwell", Price = 49.99, CategoryId = 1 },
                new Product { Id = 2, Title = "The Martian", Description = "Sci-fi survival story", Author = "Andy Weir", Price = 59.99, CategoryId = 2 },
                new Product { Id = 3, Title = "Brave New World", Description = "Classic dystopia", Author = "Aldous Huxley", Price = 39.99, CategoryId = 1 },
                new Product { Id = 4, Title = "Sapiens", Description = "A brief history of humankind", Author = "Yuval Noah Harari", Price = 64.99, CategoryId = 3 },
                new Product { Id = 5, Title = "Clean Code", Description = "Best practices for writing clean code", Author = "Robert C. Martin", Price = 74.99, CategoryId = 4 },
                new Product { Id = 6, Title = "Meditations", Description = "Thoughts of Marcus Aurelius", Author = "Marcus Aurelius", Price = 29.99, CategoryId = 5 },
                new Product { Id = 7, Title = "Astrophysics for People in a Hurry", Description = "Science made simple", Author = "Neil deGrasse Tyson", Price = 41.99, CategoryId = 2 },
                new Product { Id = 8, Title = "The Selfish Gene", Description = "Evolution explained", Author = "Richard Dawkins", Price = 52.99, CategoryId = 2 },
                new Product { Id = 9, Title = "The Art of War", Description = "Classic Chinese military treatise", Author = "Sun Tzu", Price = 24.99, CategoryId = 3 },
                new Product { Id = 10, Title = "The Republic", Description = "Philosophical dialogue by Plato", Author = "Plato", Price = 34.99, CategoryId = 5 }
            );
        }
    }
}
