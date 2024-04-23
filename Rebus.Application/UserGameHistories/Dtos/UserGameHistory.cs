using Rebus.Application.Games.Dtos;
using Rebus.Application.Roles.Dtos;

namespace Rebus.Application.UserGameHistories.Dtos;
public class UserGameHistoryDto
{
    public int UserGameHistoryId { get; set; }

    public RoleDto Role { get; set; } = null!;
    public GameDto Game { get; set; } = null!;
    public DateTime AccessStart { get; set; }
    public DateTime AccessEnd { get; set; }

}
