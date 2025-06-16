using MediatR;
using UserService.Domain.Interfaces;

namespace UserService.Application.UseCases.Commands.Handlers;

public class DeleteUserHandler(IUserRepository repository) : IRequestHandler<DeleteUserCommand>
{
    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"DeleteUserHandler: id={request.Id}, currentUserId={request.CurrentUserId}, role={request.CurrentUserRole}");
        var user = await repository.GetByIdAsync(request.Id);
        if (user == null) throw new Exception("User not found");

        if (request.CurrentUserRole != "Admin")
            throw new UnauthorizedAccessException("Only admins can delete users");

        await repository.DeleteAsync(user.Id);
    }
}