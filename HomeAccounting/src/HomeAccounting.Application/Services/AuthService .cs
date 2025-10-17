using HomeAccounting.Api.src.HomeAccounting.Application.DTOs;
using HomeAccounting.Api.src.HomeAccounting.Application.Interfaces;
using HomeAccounting.Api.src.HomeAccounting.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace HomeAccounting.Api.src.HomeAccounting.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;

        public AuthService(IUserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _config = config;
        }

        public async Task<string> RegisterAsync(UserRegisterDto dto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(dto.Email);
            if (existingUser != null)
                throw new Exception("Bu email allaqachon ro‘yxatdan o‘tgan!");

            User user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                  Role = "User"
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveAsync();

            return GenerateToken(user);
        }

        public async Task<string> LoginAsync(UserLoginDto dto)
        {
            User? user = await _userRepository.GetByEmailAsync(dto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                throw new Exception("Email yoki parol noto‘g‘ri!");

            return GenerateToken(user);
        }

        private string GenerateToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Role, user.Role)
            };

           
            string jwtKey = _config["Jwt:Key"];
            string jwtIssuer = _config["Jwt:Issuer"];
            string jwtAudience = _config["Jwt:Audience"];

            if (string.IsNullOrEmpty(jwtKey))
                throw new Exception("JWT kaliti (Jwt:Key) appsettings.json faylida topilmadi!");

           
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            JwtSecurityToken token = new JwtSecurityToken(
                issuer: jwtIssuer,
                audience: jwtAudience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
