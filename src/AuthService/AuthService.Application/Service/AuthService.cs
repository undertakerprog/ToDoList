using AuthService.Application.DTOs;
using AuthService.Application.Helpers;
using AuthService.Application.Interfaces;
using AuthService.Domain.Entities;
using AuthService.Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace AuthService.Application.Service;

public class AuthService(IAuthRepository repository, IConfiguration configuration) : IAuthService
{
    public async Task<AuthResponseDto> RegisterAsync(RegisterDto dto)
    {
        var existingUser = await repository.GetByEmailAsync(dto.Email);
        if (existingUser != null) throw new Exception("User already exists");

        var user = new User
        {
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            CreatedAt = DateTime.UtcNow
        };
        await repository.AddAsync(user);

        var token = JwtTokenHelper.GenerateJwtToken(user, configuration);
        return new AuthResponseDto { Token = token, UserId = user.Id.ToString() };
    }

    public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
    {
        var user = await repository.GetByEmailAsync(dto.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            throw new Exception("Invalid credentials");

        var token = JwtTokenHelper.GenerateJwtToken(user, configuration);
        return new AuthResponseDto { Token = token, UserId = user.Id.ToString() };
    }
}