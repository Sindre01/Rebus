
using FluentValidation;
using Rebus.Application.Users.Dtos;

namespace Rebus.Application.Users.Validators;

public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
{
    public CreateUserDtoValidator()
    {
        RuleFor(dto => dto.UserName)
            .Length(3, 100);

        //RuleFor(dto => dto.Description)
        //  .NotEmpty().WithMessage("Description is required");

        RuleFor(dto => dto.Email)
            .EmailAddress()
            .WithMessage("Please provide a valid email adress");

        RuleFor(dto => dto.PostalCode)
            .Matches(@"^\d{2}-\d{3}$")
            .WithMessage("Please provide a valid postal code (XX-XXX).");
    }
}
