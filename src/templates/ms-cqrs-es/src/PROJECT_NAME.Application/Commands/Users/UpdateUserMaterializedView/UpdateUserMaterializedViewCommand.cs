using MediatR;
using PROJECT_NAME.Application.Models;
using PROJECT_NAME.Domain.Models;

namespace PROJECT_NAME.Application.Commands;

public class UpdateUserMaterializedViewCommand : IRequest<Result<UserEntity>>
{
    public Guid Id { get; init; } = Guid.Empty;
}