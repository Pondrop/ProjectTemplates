using FluentValidation;

namespace PROJECT_NAME.Application.Queries;

public class GetAllShoppingListsQueryHandlerValidator : AbstractValidator<GetAllShoppingListsQuery>
{
    public GetAllShoppingListsQueryHandlerValidator()
    {
        RuleFor(x => x.StreamType).NotEmpty();
    }
}