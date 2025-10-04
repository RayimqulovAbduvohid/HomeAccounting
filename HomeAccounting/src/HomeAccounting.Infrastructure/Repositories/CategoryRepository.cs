using HomeAccounting.src.HomeAccounting.Application.Interfaces;
using HomeAccounting.src.HomeAccounting.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeAccounting.src.HomeAccounting.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<Category>> GetAllAsync()
            => await _context.Categories.ToListAsync();

        public async Task<Category?> GetByIdAsync(int id)
            => await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);

        public async Task AddAsync(Category category)
            => await _context.Categories.AddAsync(category);

        public void Update(Category category)
            => _context.Categories.Update(category);

        public void Delete(Category category)
            => _context.Categories.Remove(category);

        public async Task SaveAsync()
            => await _context.SaveChangesAsync();
    }
}
