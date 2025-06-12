using MediatR;
using UserService.Application.DTOs;
using UserService.Application.UseCases.Queries;
using UserService.Application.UseCases.Queries.Handlers;
using UserService.Domain.Interfaces;

namespace UserService.Application.UseCases.Commands.Handlers;

public class UpdateUserHandler(IUserRepository repository) : IRequestHandler<UpdateUserCommand, UserDto>
{
    public async Task<UserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await repository.GetByIdAsync(request.CurrentUserId);
        if (user == null) throw new Exception("User not found");

        if (user.Id != request.CurrentUserId) throw new UnauthorizedAccessException("Only the account owner can update this user");

        user.Email = request.Dto.Email;
        await repository.UpdateAsync(user);
        return await new GetUserByIdHandler(repository).Handle(new GetUserByIdQuery(request.CurrentUserId), cancellationToken);
    }
}