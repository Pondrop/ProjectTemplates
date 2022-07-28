using FluentValidation;

namespace PROJECT_NAME.Application.Commands;

public class UpdateUserNameCommandHandlerValidator : AbstractValidator<UpdateUserNameCommand>
{
    public UpdateUserNameCommandHandlerValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotNull();
    }
}