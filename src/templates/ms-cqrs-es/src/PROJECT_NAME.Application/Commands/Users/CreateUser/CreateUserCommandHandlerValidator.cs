using FluentValidation;

namespace PROJECT_NAME.Application.Commands;

public class CreateUserCommandHandlerValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandHandlerValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotNull();
        RuleFor(x => x.Email).EmailAddress();
    }
}