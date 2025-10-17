using HomeAccounting.Api.src.HomeAccounting.Application.DTOs;
using System.Threading.Tasks;

namespace HomeAccounting.Api.src.HomeAccounting.Application.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(UserRegisterDto dto);
        Task<string> LoginAsync(UserLoginDto dto);
    }
}
