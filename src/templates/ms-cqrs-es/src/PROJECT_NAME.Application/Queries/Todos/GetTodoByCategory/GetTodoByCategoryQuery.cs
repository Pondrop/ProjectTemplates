using MediatR;
using PROJECT_NAME.Application.Models;
using PROJECT_NAME.Domain.Models;

namespace PROJECT_NAME.Application.Queries;

public class GetTodoByCategoryQuery : IRequest<Result<List<TodoItem>>>
{
    public string Category { get; init; } = string.Empty;
}