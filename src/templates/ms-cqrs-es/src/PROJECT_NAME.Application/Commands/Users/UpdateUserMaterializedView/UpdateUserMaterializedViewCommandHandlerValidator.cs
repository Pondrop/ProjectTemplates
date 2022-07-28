using FluentValidation;

namespace PROJECT_NAME.Application.Commands;

public class UpdateUserMaterializedViewCommandHandlerValidator : AbstractValidator<UpdateUserMaterializedViewCommand>
{
    public UpdateUserMaterializedViewCommandHandlerValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}