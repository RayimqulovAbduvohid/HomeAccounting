using HomeAccounting.src.HomeAccounting.Application.Interfaces;
using HomeAccounting.src.HomeAccounting.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeAccounting.src.HomeAccounting.Infrastructure.Repositories
{
    public class ExpenseRepository : IExpenseRepository
    {
        private readonly AppDbContext _context;
        public ExpenseRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Expense>> GetAllAsync()
            => await _context.Expenses.Include(x => x.Category).ToListAsync();

        public async Task<Expense?> GetByIdAsync(int id)
            => await _context.Expenses.Include(x => x.Category)
                                      .FirstOrDefaultAsync(x => x.Id == id);

        public async Task AddAsync(Expense expense)
            => await _context.Expenses.AddAsync(expense);

        public void Update(Expense expense)
            => _context.Expenses.Update(expense);

        public void Delete(Expense expense)
            => _context.Expenses.Remove(expense);

        public async Task SaveAsync()
            => await _context.SaveChangesAsync();
    }


}
