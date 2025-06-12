using MediatR;
using UserService.Application.DTOs;
using UserService.Domain.Interfaces;

namespace UserService.Application.UseCases.Queries.Handlers;

public class GetAllUsersHandler(IUserRepository repository) : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
{
    public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
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
}