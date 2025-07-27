using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataAccess.SeedData
{
    public static class CategorySeedData
    {
        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, catName = "Fiction", catOrder = 1, markedAsDeleted = false },
                new Category { Id = 2, catName = "Science", catOrder = 2, markedAsDeleted = false },
                new Category { Id = 3, catName = "History", catOrder = 3, markedAsDeleted = false },
                new Category { Id = 4, catName = "Technology", catOrder = 4, markedAsDeleted = false },
                new Category { Id = 5, catName = "Philosophy", catOrder = 5, markedAsDeleted = false }
            );
        }
    }
}
