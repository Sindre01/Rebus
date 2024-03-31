using Rebus.Application.Games.Dtos;
using Rebus.Application.Roles.Dtos;
using Rebus.Application.Users.Dtos;

namespace Rebus.Application.GameCreators.Dtos;
public class GameCreatorDto
{
    public int GameCreatorId { get; set; }
    public DateTime StartTime { get; set; }
    public UserDto User { get; set; } = null!; // Required reference navigation to principal
    public GameDto Game { get; set; } = null!; // Required reference navigation to principal
    public RoleDto Role { get; set; } = null!; // Required reference navigation to principal
}