using MediatR;

namespace UserService.Application.UseCases.Commands;

public record MakeAdminCommand(int Id, int CurrentUserId) : IRequest;