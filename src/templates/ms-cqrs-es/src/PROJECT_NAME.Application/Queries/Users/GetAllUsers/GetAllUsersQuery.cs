using MediatR;
using PROJECT_NAME.Application.Models;
using PROJECT_NAME.Domain.Models;

namespace PROJECT_NAME.Application.Queries;

public class GetAllUsersQuery : IRequest<Result<List<UserRecord>>>
{
    public string StreamType { get; } = EventEntity.GetStreamTypeName<UserEntity>();
}