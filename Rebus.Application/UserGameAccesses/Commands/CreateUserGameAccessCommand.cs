using MediatR;
using Rebus.Application.Games.Dtos;
using Rebus.Application.Users.Dtos;

namespace Rebus.Application.UserGameAccesses.Commands.CreateUserGameAccess;

public class CreateUserGameAccessCommand : IRequest
{
    public int GameUserAccessId { get; set; }
    public UserDto User { get; set; } = null!; // Required reference navigation to principal
    public GameDto Game { get; set; } = null!; // Required reference navigation to principal
    public DateTime AccessTime { get; set; }
}
