using Rebus.Application.Games.Dtos;
using Rebus.Application.Roles.Dtos;
using Rebus.Application.Users.Dtos;

namespace Rebus.Application.UserGameHistories.Dtos;
public class UserGameHistoryDto
{
    public int UserGameHistoryId { get; set; }
    public UserDto User { get; set; } = null!;
    public RoleDto Role { get; set; } = null!;
    public GameDto Game { get; set; } = null!;
    public DateTime AccessStart { get; set; }
    public DateTime AccessEnd { get; set; }

}
