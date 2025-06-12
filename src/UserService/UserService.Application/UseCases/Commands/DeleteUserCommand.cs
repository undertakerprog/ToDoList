using MediatR;

namespace UserService.Application.UseCases.Commands;

public record DeleteUserCommand(int Id, int CurrentUserId) : IRequest;