using MediatR;
using UserService.Domain.Interfaces;

namespace UserService.Application.UseCases.Commands.Handlers;

public class DeleteUserHandler(IUserRepository repository) : IRequestHandler<DeleteUserCommand>
{
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await repository.GetByIdAsync(request.Id);
        if (user == null) throw new Exception("User not found");

        if (user.Id != request.CurrentUserId) throw new UnauthorizedAccessException("Only the account owner can delete this user");

        await repository.DeleteAsync(request.Id);
    }
}