namespace UserService.Application.DTOs;

public class UserDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public DateTime CreatedAt { get; set; }
}