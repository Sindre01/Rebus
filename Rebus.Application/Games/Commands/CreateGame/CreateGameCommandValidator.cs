using FluentValidation;

namespace Rebus.Application.Games.Commands.CreateGame;

public  class CreateGameCommandValidator : AbstractValidator<CreateGameCommand>
{
    public CreateGameCommandValidator()
    {
        RuleFor(game => game.CurrentPlayers)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Current players must be a positive number");

        RuleFor(game => game.MaxPlayers)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Max players must be a positive number");
    }

}
