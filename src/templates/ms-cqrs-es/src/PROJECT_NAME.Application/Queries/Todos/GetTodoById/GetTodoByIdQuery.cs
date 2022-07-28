using MediatR;
using PROJECT_NAME.Application.Models;
using PROJECT_NAME.Domain.Models;

namespace PROJECT_NAME.Application.Queries;

public class GetTodoByIdQuery : IRequest<Result<TodoItem>>
{
    public Guid Id { get; init; } = Guid.Empty;
    public string Category { get; init; } = string.Empty;
}