using HomeAccounting.src.HomeAccounting.Domain.Entities;

namespace HomeAccounting.src.HomeAccounting.Application.Interfaces
{
    public interface IExpenseRepository
    {
        Task<IEnumerable<Expense>> GetAllAsync();
        Task<Expense?> GetByIdAsync(int id);
        Task AddAsync(Expense expense);
        void Update(Expense expense);
        void Delete(Expense expense);
        Task SaveAsync();
    }

}
