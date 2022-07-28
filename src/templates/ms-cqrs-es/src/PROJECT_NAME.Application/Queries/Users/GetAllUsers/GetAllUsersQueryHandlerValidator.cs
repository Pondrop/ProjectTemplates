using FluentValidation;

namespace PROJECT_NAME.Application.Queries;

public class GetAllUsersQueryHandlerValidator : AbstractValidator<GetAllUsersQuery>
{
    public GetAllUsersQueryHandlerValidator()
    {
        RuleFor(x => x.StreamType).NotEmpty();
    }
}