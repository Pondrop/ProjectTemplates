using FluentValidation;

namespace PROJECT_NAME.Application.Queries;

public class GetTodoByIdQueryHandlerValidator : AbstractValidator<GetTodoByIdQuery>
{
    public GetTodoByIdQueryHandlerValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Category).NotEmpty();
    }
}