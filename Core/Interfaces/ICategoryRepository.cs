using Models.Entities;

namespace Core.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<List<Category>> GetAllWithProductsAsync();
    }
}
