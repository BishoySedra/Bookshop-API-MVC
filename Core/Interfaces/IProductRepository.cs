using Models.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<List<Product>> GetAllWithCategoriesAsync();
        Task<Product> GetByIdAsync(int id);
        void Add(Product product);
        void Remove(Product product);
        Task<List<Product>> GetProductsByCategoryIdAsync(int categoryId);

        Task<Product> GetByIdWithCategoryAsync(int id);
    }
}
