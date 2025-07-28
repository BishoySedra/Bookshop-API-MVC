using DataAccess;
using Core.Interfaces;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public ICategoryRepository Categories { get; }

    public UnitOfWork(ApplicationDbContext context, ICategoryRepository categoryRepository)
    {
        _context = context;
        Categories = categoryRepository;
    }

    public async Task<int> SaveAsync() => await _context.SaveChangesAsync();
    public void Dispose() => _context.Dispose();
}
