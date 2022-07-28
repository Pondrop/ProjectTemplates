namespace PROJECT_NAME.Domain.Models;

public record ShoppingListRecord(Guid Id, Guid UserId, string Name, string Description, List<ShoppingListItemRecord> Items);