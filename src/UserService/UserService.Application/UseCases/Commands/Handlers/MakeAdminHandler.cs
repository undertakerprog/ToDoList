using MediatR;
using UserService.Domain.Interfaces;

namespace UserService.Application.UseCases.Commands.Handlers;

public class MakeAdminHandler(IUserRepository repository) : IRequestHandler<MakeAdminCommand>
{
    public async Task Handle(MakeAdminCommand request, CancellationToken cancellationToken)
    {
        Console.WriteLine($"MakeAdminHandler: id={request.Id}, currentUserId={request.CurrentUserId}, role={request.CurrentUserRole}");
        var user = await repository.GetByIdAsync(request.Id);
        if (user == null) throw new Exception("User not found");

        if (request.CurrentUserRole != "Admin")
            throw new UnauthorizedAccessException("Only admins can make other users admins");

        user.Role = "Admin";
        await repository.UpdateAsync(user);
    }
}