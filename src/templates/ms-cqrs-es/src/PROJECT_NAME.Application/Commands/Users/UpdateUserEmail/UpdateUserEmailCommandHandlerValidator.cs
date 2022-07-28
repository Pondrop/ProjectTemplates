using FluentValidation;

namespace PROJECT_NAME.Application.Commands;

public class UpdateUserEmailCommandHandlerValidator : AbstractValidator<UpdateUserEmailCommand>
{
    public UpdateUserEmailCommandHandlerValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Email).EmailAddress();
    }
}