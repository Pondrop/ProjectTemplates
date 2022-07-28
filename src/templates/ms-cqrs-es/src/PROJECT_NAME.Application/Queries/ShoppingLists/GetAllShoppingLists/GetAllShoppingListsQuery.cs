using MediatR;
using PROJECT_NAME.Application.Models;
using PROJECT_NAME.Domain.Models;

namespace PROJECT_NAME.Application.Queries;

public class GetAllShoppingListsQuery : IRequest<Result<List<ShoppingListRecord>>>
{
    public string StreamType { get; } = EventEntity.GetStreamTypeName<ShoppingListEntity>();
}