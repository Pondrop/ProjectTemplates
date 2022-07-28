using PROJECT_NAME.Application.Commands;
using PROJECT_NAME.Domain.Models;

namespace PROJECT_NAME.Application.Interfaces;

public interface ITodoRepository
{
    Task<bool> IsConnectedAsync();

    Task<TodoItem?> AddItemAsync(CreateTodoCommand item);
    Task<TodoItem?> ReplaceItemAsync(TodoItem item);
    Task<bool> DeleteItemAsync(TodoItem item);

    Task<List<TodoItem>> QueryItemsAsync(string sqlQueryText);
    Task<List<TodoItem>> QueryItemsAsync(string sqlQueryText, Dictionary<string, string> parameters);
}