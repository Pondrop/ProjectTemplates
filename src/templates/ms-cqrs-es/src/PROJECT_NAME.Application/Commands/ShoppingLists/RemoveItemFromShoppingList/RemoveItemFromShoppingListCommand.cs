using MediatR;
using PROJECT_NAME.Application.Models;
using PROJECT_NAME.Domain.Models;

namespace PROJECT_NAME.Application.Commands;

public class RemoveItemFromShoppingListCommand : IRequest<Result<ShoppingListRecord>>
{
    public Guid Id { get; init; } = Guid.Empty;
    public Guid ShoppingListId { get; init; } = Guid.Empty;
}