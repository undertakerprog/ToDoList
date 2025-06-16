using MediatR;
using UserService.Application.DTOs;

namespace UserService.Application.UseCases.Commands;

public record UpdateUserCommand(int Id, UpdateUserDto Dto, string CurrentUserId) : IRequest<UserDto>;