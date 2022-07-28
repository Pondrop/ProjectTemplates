using FluentValidation;

namespace PROJECT_NAME.Application.Commands;

public class CreateTodoCommandHandlerValidator : AbstractValidator<CreateTodoCommand>
{
    public CreateTodoCommandHandlerValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotNull();
        RuleFor(x => x.Category).NotEmpty();
    }
}