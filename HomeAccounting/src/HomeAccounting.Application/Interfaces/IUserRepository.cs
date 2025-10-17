using HomeAccounting.Api.src.HomeAccounting.Domain.Entities;

namespace HomeAccounting.Api.src.HomeAccounting.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email);
        Task AddAsync(User user);
        Task SaveAsync();
    }
}
