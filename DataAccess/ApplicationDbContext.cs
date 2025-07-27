using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets for each entity in the application
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply all Fluent API configurations from the Models project
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Category).Assembly);

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    catName = "Fiction",
                    catOrder = 1,
                    markedAsDeleted = false
                },
                new Category
                {
                    Id = 2,
                    catName = "Science",
                    catOrder = 2,
                    markedAsDeleted = false
                }
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "1984",
                    Description = "Dystopian novel",
                    Author = "George Orwell",
                    Price = 49.99,
                    CategoryId = 1 // Fiction
                },
                new Product
                {
                    Id = 2,
                    Title = "The Martian",
                    Description = "Sci-fi survival story",
                    Author = "Andy Weir",
                    Price = 59.99,
                    CategoryId = 2 // Science
                },
                new Product
                {
                    Id = 3,
                    Title = "Brave New World",
                    Description = "Classic dystopia",
                    Author = "Aldous Huxley",
                    Price = 39.99,
                    CategoryId = 1 // Fiction
                }
            );

            base.OnModelCreating(modelBuilder);
        }

    }
}
