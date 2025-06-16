using MediatR;
using UserService.Application.DTOs;
using UserService.Domain.Interfaces;

namespace UserService.Application.UseCases.Commands.Handlers;

public class UpdateUserHandler(IUserRepository repository) : IRequestHandler<UpdateUserCommand, UserDto>
{
    public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"UpdateUserHandler: id={request.Id}, currentUserId={request.CurrentUserId}");
        var user = await repository.GetByIdAsync(int.Parse(request.Id.ToString()));
        if (user == null) throw new Exception("User to update not found");

        var isOwner = user.Id.ToString() == request.CurrentUserId;
        if (!isOwner)
            throw new UnauthorizedAccessException("Only the account owner can update this user");

        user.Email = request.Dto.Email;
        await repository.UpdateAsync(user);
        return new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            Role = user.Role,
            CreatedAt = user.CreatedAt
        };
    }
}