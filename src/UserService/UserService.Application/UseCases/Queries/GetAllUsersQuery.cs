using MediatR;
using UserService.Application.DTOs;

namespace UserService.Application.UseCases.Queries;

public record GetAllUsersQuery() : IRequest<IEnumerable<UserDto>>;