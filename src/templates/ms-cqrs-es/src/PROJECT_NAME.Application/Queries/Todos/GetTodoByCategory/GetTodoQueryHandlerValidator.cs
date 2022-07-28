using FluentValidation;

namespace PROJECT_NAME.Application.Queries;

public class GetTodoByCategoryQueryHandlerValidator : AbstractValidator<GetTodoByCategoryQuery>
{
    public GetTodoByCategoryQueryHandlerValidator()
    {
        RuleFor(x => x.Category).NotEmpty();
    }
}