using MediatR;
using UserService.Application.DTOs;
using UserService.Domain.Interfaces;

namespace UserService.Application.UseCases.Queries.Handlers;

public class GetUserByIdHandler(IUserRepository repository) : IRequestHandler<GetUserByIdQuery, UserDto>
{
    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await repository.GetByIdAsync(request.Id);
        if (user == null) throw new Exception("User not found");
        return new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            Role = user.Role,
            CreatedAt = user.CreatedAt
        };
    }
}