using MediatR;

namespace UserService.Application.UseCases.Commands;

public record DeleteUserCommand(int Id, string CurrentUserId, string CurrentUserRole) : IRequest;