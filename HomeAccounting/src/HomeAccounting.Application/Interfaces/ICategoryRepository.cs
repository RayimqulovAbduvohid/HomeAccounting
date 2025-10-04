using HomeAccounting.src.HomeAccounting.Domain.Entities;

namespace HomeAccounting.src.HomeAccounting.Application.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task AddAsync(Category category);
        void Update(Category category);
        void Delete(Category category);
        Task SaveAsync();
    }

}
