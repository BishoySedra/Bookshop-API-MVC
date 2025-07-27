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

            base.OnModelCreating(modelBuilder);
        }
    }
}
