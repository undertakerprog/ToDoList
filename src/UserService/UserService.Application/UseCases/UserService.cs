using UserService.Application.DTOs;
using UserService.Application.Interfaces;
using UserService.Domain.Interfaces;

namespace UserService.Application.UseCases;

public class UserService(IUserRepository repository) : IUserService
{
    public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
    {
        var users = await repository.GetAllAsync();
        return users.Select(u => new UserDto
        {
            Id = u.Id,
            Email = u.Email,
            Role = u.Role,
            CreatedAt = u.CreatedAt
        });
    }

    public async Task<UserDto> GetUserByIdAsync(int id)
    {
        var user = await repository.GetByIdAsync(id);
        if (user == null) throw new Exception("User not found");
        return new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            Role = user.Role,
            CreatedAt = user.CreatedAt
        };
    }

    public async Task<UserDto> UpdateUserAsync(UpdateUserDto dto, int currentUserId)
    {
        var user = await repository.GetByIdAsync(currentUserId);
        if (user == null) throw new Exception("User not found");
        
        if (user.Id != currentUserId) throw new UnauthorizedAccessException("Only the account owner can update this user");

        user.Email = dto.Email;
        await repository.UpdateAsync(user);
        return await GetUserByIdAsync(currentUserId);
    }

    public async Task DeleteUserAsync(int id, int currentUserId)
    {
        var user = await repository.GetByIdAsync(id);
        if (user == null) throw new Exception("User not found");
        
        if (user.Id != currentUserId) throw new UnauthorizedAccessException("Only the account owner can delete this user");

        await repository.DeleteAsync(id);
    }

    public async Task MakeAdminAsync(int id, int currentUserId)
    {
        var user = await repository.GetByIdAsync(id);
        if (user == null) throw new Exception("User not found");
        
        if (user.Id != currentUserId) throw new UnauthorizedAccessException("Only the account owner can change their role");

        user.Role = "Admin";
        await repository.UpdateAsync(user);
    }
}