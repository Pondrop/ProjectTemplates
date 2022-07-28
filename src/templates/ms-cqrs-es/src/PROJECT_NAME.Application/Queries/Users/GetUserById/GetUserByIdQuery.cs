using MediatR;
using PROJECT_NAME.Application.Models;
using PROJECT_NAME.Domain.Models;

namespace PROJECT_NAME.Application.Queries;

public class GetUserByIdQuery : IRequest<Result<UserRecord>>
{
    public Guid Id { get; init; } = Guid.Empty;
}