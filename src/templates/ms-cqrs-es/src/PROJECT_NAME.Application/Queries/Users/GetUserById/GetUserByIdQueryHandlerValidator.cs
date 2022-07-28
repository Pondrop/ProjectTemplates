using FluentValidation;

namespace PROJECT_NAME.Application.Queries;

public class GetUserByIdQueryHandlerValidator : AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdQueryHandlerValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}