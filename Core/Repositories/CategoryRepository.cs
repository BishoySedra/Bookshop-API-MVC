using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Core.Interfaces;
using DataAccess.Repositories;
using DataAccess;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{

    public CategoryRepository(DbContext context) : base(context)
    {
    }

    public async Task<List<Category>> GetAllWithProductsAsync()
    {
        // Cast base DbContext (_context) to mainContext to access Categories DbSet
        var context = _context as ApplicationDbContext;

        return await _context.Set<Category>()
            .Include(c => c.Products)
            .ToListAsync();
    }
}
