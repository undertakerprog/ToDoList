using AuthService.Application.DTOs;
using AuthService.Application.Helpers;
using AuthService.Application.Interfaces;
using AuthService.Domain.Entities;
using AuthService.Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace AuthService.Application.UseCases;

public class RegisterUseCase(IAuthRepository repository, IConfiguration configuration) : IAuthService
{
    public async Task<AuthResponseDto> RegisterAsync(RegisterDto dto)
    {
        var existingUser = await repository.GetByEmailAsync(dto.Email);
        if (existingUser != null) throw new Exception("User already exists");

        var user = new User
        {
            Id = new Random().Next(1, 10000),
            Email = dto.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            CreatedAt = DateTime.UtcNow
        };
        await repository.AddAsync(user);

        var token = JwtTokenHelper.GenerateJwtToken(user, configuration);
        return new AuthResponseDto { Token = token, UserId = user.Id.ToString() };
    }

    public Task<AuthResponseDto> LoginAsync(LoginDto dto) => throw new NotImplementedException();
}