using MediatR;
using UserService.Application.DTOs;

namespace UserService.Application.UseCases.Queries;

public record GetUserByIdQuery(int Id) : IRequest<UserDto>;