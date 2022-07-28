namespace PROJECT_NAME.Domain.Events.ShoppingList;

public record UpdateShoppingList(Guid Id, string Name, string Description) : EventPayload;