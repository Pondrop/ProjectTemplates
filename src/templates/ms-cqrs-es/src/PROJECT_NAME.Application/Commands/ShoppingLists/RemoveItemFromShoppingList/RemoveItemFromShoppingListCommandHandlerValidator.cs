using FluentValidation;

namespace PROJECT_NAME.Application.Commands;

public class RemoveItemFromShoppingListCommandHandlerValidator : AbstractValidator<RemoveItemFromShoppingListCommand>
{
    public RemoveItemFromShoppingListCommandHandlerValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.ShoppingListId).NotEmpty();
    }
}