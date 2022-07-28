using MediatR;
using PROJECT_NAME.Application.Models;
using PROJECT_NAME.Domain.Models;

namespace PROJECT_NAME.Application.Commands;

public class CreateUserCommand : IRequest<Result<UserRecord>>
{
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
    public string Email { get; init; } = string.Empty;
}