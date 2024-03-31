using Rebus.Application.GameAccessCodes.Dtos;
using Rebus.Application.GameCreators.Dtos;
using Rebus.Application.UserGameHistories.Dtos;
using Rebus.Application.Users.Dtos;
using Rebus.Domain.Entities;

namespace Rebus.Application.GameUserAccesses.Dtos;
public class GameUserAccessDto
{
    public int GameUserAccessId { get; set; }
    public UserDto User { get; set; } = null!; // Required reference navigation to principal
    public GameAccessCodeDto GameAccessCode { get; set; } = null!; // Required reference navigation to principal
    public DateTime AccessTime { get; set; }
    public static GameUserAccessDto? FromEntity(GameUserAccess? GameUserAccess)
    {
        if (GameUserAccess == null) return null;

        return new GameUserAccessDto()
        {
          GameUserAccessId = GameUserAccess.GameUserAccessId,
          User = GameUserAccess.User != null ? UserDto.FromEntity(GameUserAccess.User)! : throw new InvalidOperationException("User cannot be null."),
          GameAccessCode = GameUserAccess.GameAccessCode != null ? GameAccessCodeDto.FromEntity(GameUserAccess.GameAccessCode)! : throw new InvalidOperationException("GameAccessCode cannot be null."),
          AccessTime = GameUserAccess.AccessTime,
        };
    }
}
