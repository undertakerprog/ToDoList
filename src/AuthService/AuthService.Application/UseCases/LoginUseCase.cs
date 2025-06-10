using AuthService.Application.DTOs;
using AuthService.Application.Helpers;
using AuthService.Application.Interfaces;
using AuthService.Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace AuthService.Application.UseCases;

public class LoginUseCase(IAuthRepository repository, IConfiguration configuration) : IAuthService
{
    public Task<AuthResponseDto> RegisterAsync(RegisterDto dto) => throw new NotImplementedException();

    public async Task<AuthResponseDto> LoginAsync(LoginDto dto)
    {
        var user = await repository.GetByEmailAsync(dto.Email);
        if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            throw new Exception("Invalid credentials");

        var token = JwtTokenHelper.GenerateJwtToken(user, configuration);
        return new AuthResponseDto { Token = token, UserId = user.Id.ToString() };
    }
}