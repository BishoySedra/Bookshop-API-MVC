using Microsoft.EntityFrameworkCore;
using Models.Entities;
using DataAccess.Repositories;
using Core.Interfaces;
using DataAccess;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{

    public ProductRepository(DbContext context) : base(context)
    {
    }

    public async Task<List<Product>> GetAllWithCategoriesAsync()
    {
        // Cast base DbContext (_context) to mainContext to access Categories DbSet
        var context = _context as ApplicationDbContext;
        return await _context.Set<Product>()
            .Include(p => p.Category)
            .ToListAsync();
    }

    public async Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId)
    {
        // Cast base DbContext (_context) to mainContext to access Categories DbSet
        var context = _context as ApplicationDbContext;
        return await _context.Set<Product>()
            .Where(p => p.CategoryId == categoryId)
            .ToListAsync();
    }

    public async Task<Product> GetByIdWithCategoryAsync(int id)
    {
        // Cast base DbContext (_context) to mainContext to access Categories DbSet
        var context = _context as ApplicationDbContext;
        return await _context.Set<Product>()
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == id);
    }
}

