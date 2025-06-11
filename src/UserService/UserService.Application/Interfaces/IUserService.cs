using UserService.Application.DTOs;

namespace UserService.Application.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task<UserDto> GetUserByIdAsync(int id);
    Task<UserDto> UpdateUserAsync(UpdateUserDto dto, int currentUserId);
    Task DeleteUserAsync(int id, int currentUserId);
    Task MakeAdminAsync(int id, int currentUserId);
}