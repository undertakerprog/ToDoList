using MediatR;
using UserService.Domain.Interfaces;

namespace UserService.Application.UseCases.Commands.Handlers;

public class MakeAdminHandler(IUserRepository repository) : IRequestHandler<MakeAdminCommand>
{
    public async Task Handle(MakeAdminCommand request, CancellationToken cancellationToken)
    {
        var user = await repository.GetByIdAsync(request.Id);
        if (user == null) throw new Exception("User not found");

        if (user.Id != request.CurrentUserId) throw new UnauthorizedAccessException("Only the account owner can change their role");

        user.Role = "Admin";
        await repository.UpdateAsync(user);
    }
}