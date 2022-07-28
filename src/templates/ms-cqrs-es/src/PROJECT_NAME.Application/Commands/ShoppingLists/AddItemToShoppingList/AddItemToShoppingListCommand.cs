using MediatR;
using PROJECT_NAME.Application.Models;
using PROJECT_NAME.Domain.Models;

namespace PROJECT_NAME.Application.Commands;

public class AddItemToShoppingListCommand : IRequest<Result<ShoppingListRecord>>
{
    public Guid ShoppingListId { get; init; } = Guid.Empty;
    public string Name { get; init; } = string.Empty;
}