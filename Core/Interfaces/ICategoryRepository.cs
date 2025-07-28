using Models.Entities;

public interface ICategoryRepository
{
    Task<List<Category>> GetAllAsync();
    Task<List<Category>> GetAllWithProductsAsync();
    Task<Category?> GetByIdAsync(int id);
    void Add(Category category);
    void Remove(Category category);
}
