using MediatR;
using PROJECT_NAME.Application.Models;
using PROJECT_NAME.Domain.Models;

namespace PROJECT_NAME.Application.Commands;

public class UpdateUserEmailCommand : IRequest<Result<UserRecord>>
{
    public Guid Id { get; init; } = Guid.Empty;
    public string Email { get; init; } = string.Empty;
}