namespace PROJECT_NAME.Domain.Events.ShoppingList;

public record AddItemToShoppingList(Guid Id, Guid ShoppingListId, string Name) : EventPayload;