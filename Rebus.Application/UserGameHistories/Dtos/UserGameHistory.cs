using Rebus.Application.GameCreators.Dtos;
using Rebus.Application.Games.Dtos;
using Rebus.Application.Roles.Dtos;
using Rebus.Application.Users.Dtos;
using Rebus.Domain.Entities;

namespace Rebus.Application.UserGameHistories.Dtos;
public class UserGameHistoryDto
{
    public int UserGameHistoryId { get; set; }
    public UserDto User { get; set; } = null!;
    public RoleDto Role { get; set; } = null!;
    public GameDto Game { get; set; } = null!;
    public DateTime AccessStart { get; set; }
    public DateTime AccessEnd { get; set; }
    public static UserGameHistoryDto FromEntity(UserGameHistory UserGameHistory)
    {
        return new UserGameHistoryDto()
        {
           UserGameHistoryId = UserGameHistory.UserGameHistoryId,
           AccessEnd = UserGameHistory.AccessEnd,
           AccessStart = UserGameHistory.AccessStart,
           User = UserGameHistory.User != null ? UserDto.FromEntity(UserGameHistory.User)! : throw new InvalidOperationException("User cannot be null."),
           Game = UserGameHistory.Game != null ? GameDto.FromEntity(UserGameHistory.Game)! : throw new InvalidOperationException("Game cannot be null."),
           Role = UserGameHistory.Role != null ? RoleDto.FromEntity(UserGameHistory.Role)! : throw new InvalidOperationException("Role cannot be null."),
        };
    }
}
