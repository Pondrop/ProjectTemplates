using FluentValidation;

namespace PROJECT_NAME.Application.Commands;

public class AddItemToShoppingListCommandHandlerValidator : AbstractValidator<AddItemToShoppingListCommand>
{
    public AddItemToShoppingListCommandHandlerValidator()
    {
        RuleFor(x => x.ShoppingListId).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
    }
}