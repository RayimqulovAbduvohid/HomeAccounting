using HomeAccounting.src.HomeAccounting.Application.Interfaces;
using HomeAccounting.src.HomeAccounting.Domain.Entities;
using HomeAccounting.src.HomeAccounting.Infrastructure.Repositories;

namespace HomeAccounting.src.HomeAccounting.Application.Services
{
    public class ExpenseService : IExpenseRepository
    {
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseService(IExpenseRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;
        }

        public async Task<IEnumerable<Expense>> GetAllExpensesAsync()
            => await _expenseRepository.GetAllAsync();

        public async Task<Expense?> GetExpenseByIdAsync(int id)
            => await _expenseRepository.GetByIdAsync(id);

        public async Task AddExpenseAsync(Expense expense)
        {
            if (string.IsNullOrWhiteSpace(expense.Description))
                throw new ArgumentException("Toifa nomi bo‘sh bo‘lmasligi kerak!");

            await _expenseRepository.AddAsync(expense);
            await _expenseRepository.SaveAsync();
        }

        public async Task UpdateExpenseAsync(Expense expense)
        {
            Expense existing = await _expenseRepository.GetByIdAsync(expense.Id);
            if (existing == null)
                throw new KeyNotFoundException("Bunday xarajat topilmadi!");

            existing.Price = expense.Price;
            existing.Description = expense.Description;
            existing.CategoryId = expense.CategoryId;

            _expenseRepository.Update(existing);
            await _expenseRepository.SaveAsync();
        }

        public async Task DeleteExpenseAsync(int id)
        {
            Expense exp = await _expenseRepository.GetByIdAsync(id);
            if (exp == null)
                throw new KeyNotFoundException("O‘chiriladigan xarajat topilmadi!");

            _expenseRepository.Delete(exp);
            await _expenseRepository.SaveAsync();
        }

        public Task<IEnumerable<Expense>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Expense?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task AddAsync(Expense expense)
        {
            throw new NotImplementedException();
        }

        public void Update(Expense expense)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expense expense)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
