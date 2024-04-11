using Rebus.Application.Games.Dtos;
using Rebus.Application.Users.Dtos;

namespace Rebus.Application.UserGameAccesses.Dtos;
public class UserGameAccessDto
{
    public int GameUserAccessId { get; set; }
    public UserDto User { get; set; } = null!; // Required reference navigation to principal
    public GameDto Game { get; set; } = null!; // Required reference navigation to principal
    public DateTime AccessTime { get; set; }

}
