using Microsoft.EntityFrameworkCore;
using Models.Entities;
using DataAccess;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Category>> GetAllAsync() =>
        await _context.Categories
            .OrderBy(c => c.catOrder)
            .ThenByDescending(c => c.catName)
            .ToListAsync();

    public async Task<List<Category>> GetAllWithProductsAsync() =>
        await _context.Categories.Include(c => c.Products).ToListAsync();

    public async Task<Category> GetByIdAsync(int id) =>
        await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

    public void Add(Category category) =>
        _context.Categories.Add(category);

    public void Remove(Category category) =>
        _context.Categories.Remove(category);
}
