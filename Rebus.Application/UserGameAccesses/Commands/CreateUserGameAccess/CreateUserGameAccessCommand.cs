using MediatR;

namespace Rebus.Application.UserGameAccesses.Commands.CreateUserGameAccess;

public class CreateUserGameAccessCommand : IRequest<int>
{
    public DateTime AccessTime { get; set; }

    public int UserId { get; set; }
    public int GameId { get; set; }
}
