using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using Models.Entities;

namespace DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply all configurations from the Models project
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Category).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
