using MediatR;
using PROJECT_NAME.Application.Models;
using PROJECT_NAME.Domain.Models;

namespace PROJECT_NAME.Application.Commands;

public class UpdateUserNameCommand : IRequest<Result<UserEntity>>
{
    public Guid Id { get; init; } = Guid.Empty;
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
}