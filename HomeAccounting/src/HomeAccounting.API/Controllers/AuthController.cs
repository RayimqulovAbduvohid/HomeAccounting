using HomeAccounting.Api.src.HomeAccounting.Application.DTOs;
using HomeAccounting.Api.src.HomeAccounting.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HomeAccounting.Api.src.HomeAccounting.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto dto)
        {
            await _authService.RegisterAsync(dto);
            return Ok("Foydalanuvchi ro‘yxatdan o‘tdi");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto dto)
        {
            var token = await _authService.LoginAsync(dto);
            return Ok(new { Token = token });
        }
    }
}
