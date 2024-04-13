using MediatR;

namespace Rebus.Application.Games.Commands.DeleteGame;

public class DeleteGameCommand(int id) : IRequest<bool>
{
    public int Id { get; } = id;
}
