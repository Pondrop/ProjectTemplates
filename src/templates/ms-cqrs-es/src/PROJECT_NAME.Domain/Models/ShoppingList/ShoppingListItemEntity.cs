using Microsoft.VisualBasic;
using Newtonsoft.Json;
using PROJECT_NAME.Domain.Events;
using PROJECT_NAME.Domain.Events.ShoppingList;
using PROJECT_NAME.Domain.Events.User;

namespace PROJECT_NAME.Domain.Models;

public record ShoppingListItemEntity(Guid Id, Guid ShoppingListId, string Name);