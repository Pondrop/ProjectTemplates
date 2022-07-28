namespace PROJECT_NAME.Domain.Events.ShoppingList;

public record RemoveItemFromShoppingList(Guid Id, Guid ShoppingListId) : EventPayload;