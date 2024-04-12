using MediatR;
using Rebus.Application.Games.Dtos;
using Rebus.Application.Users.Dtos;

namespace Rebus.Application.UserGameAccesses.Commands.CreateUserGameAccess;

public class CreateUserGameAccessCommand : IRequest
{
    public DateTime AccessTime { get; set; }

    public int UserId { get; set; }
    public int GameId { get; set; }
}
