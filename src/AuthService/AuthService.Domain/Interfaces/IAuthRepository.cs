using AuthService.Domain.Entities;

namespace AuthService.Domain.Interfaces;

public interface IAuthRepository
{
    Task<User?> GetByEmailAsync(string email);
    Task AddAsync(User user);
}