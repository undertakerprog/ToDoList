using MediatR;

namespace UserService.Application.UseCases.Commands;

public record MakeAdminCommand(int Id, string CurrentUserId, string CurrentUserRole) : IRequest;