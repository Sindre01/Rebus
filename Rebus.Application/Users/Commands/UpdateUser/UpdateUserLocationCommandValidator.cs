using FluentValidation;

namespace Rebus.Application.Users.Commands.UpdateUser;

public class UpdateUserLocationCommandValidator : AbstractValidator<UpdateUserLocationCommand>
{
    public UpdateUserLocationCommandValidator()
    {
 /*       RuleFor(c => c.UserName)
            .Length(3, 100);
        RuleFor(c => c.FullName)
            .Length(3, 100);*/
    }
}
