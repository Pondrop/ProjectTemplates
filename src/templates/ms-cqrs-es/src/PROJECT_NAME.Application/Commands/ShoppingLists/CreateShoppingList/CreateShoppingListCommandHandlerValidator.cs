using FluentValidation;

namespace PROJECT_NAME.Application.Commands;

public class CreateShoppingListCommandHandlerValidator : AbstractValidator<CreateShoppingListCommand>
{
    public CreateShoppingListCommandHandlerValidator()
    {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotNull();
    }
}