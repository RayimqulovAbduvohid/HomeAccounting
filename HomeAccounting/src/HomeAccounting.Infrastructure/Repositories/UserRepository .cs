using HomeAccounting.Api.src.HomeAccounting.Application.Interfaces;
using HomeAccounting.Api.src.HomeAccounting.Domain.Entities;
using HomeAccounting.src.HomeAccounting.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace HomeAccounting.Api.src.HomeAccounting.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User?> GetByEmailAsync(string email)
            => await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

        public async Task AddAsync(User user)
            => await _context.Users.AddAsync(user);

        public async Task SaveAsync()
            => await _context.SaveChangesAsync();
    }
}
