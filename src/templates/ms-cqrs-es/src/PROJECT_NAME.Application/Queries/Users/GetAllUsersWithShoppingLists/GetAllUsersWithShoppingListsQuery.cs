using MediatR;
using PROJECT_NAME.Application.Models;
using PROJECT_NAME.Domain.Models;

namespace PROJECT_NAME.Application.Queries;

public class GetAllUsersWithShoppingListsQuery : IRequest<Result<List<UserWithShoppingListsRecord>>>
{
    public string UserStreamType { get; } = EventEntity.GetStreamTypeName<UserEntity>();
    public string ShoppingListStreamType { get; } = EventEntity.GetStreamTypeName<ShoppingListEntity>();
}