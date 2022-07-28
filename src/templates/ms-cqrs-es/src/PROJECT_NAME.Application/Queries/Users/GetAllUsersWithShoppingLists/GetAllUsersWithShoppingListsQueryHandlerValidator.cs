using FluentValidation;

namespace PROJECT_NAME.Application.Queries;

public class GetAllUsersAndShoppingListsQueryHandlerValidator : AbstractValidator<GetAllUsersWithShoppingListsQuery>
{
    public GetAllUsersAndShoppingListsQueryHandlerValidator()
    {
        RuleFor(x => x.UserStreamType).NotEmpty();
        RuleFor(x => x.ShoppingListStreamType).NotEmpty();
    }
}