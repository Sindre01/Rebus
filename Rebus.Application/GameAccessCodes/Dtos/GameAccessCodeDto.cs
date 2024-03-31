using Rebus.Application.Games.Dtos;
using Rebus.Application.GameUserAccesses.Dtos;
using Rebus.Application.Users.Dtos;
using Rebus.Domain.Entities;
namespace Rebus.Application.GameAccessCodes.Dtos;
public class GameAccessCodeDto
{
    public int GameAccessCodeId { get; set; }
    //public GameDto Game { get; set; } = null!;
    public int GameId { get; set; }
    public bool IsActive { get; set; }
    //public List<GameUserAccessDto> GameUserAccesses { get; set; } = [];
    public int? UsageLimit { get; set; }
    public int? TimeUsed { get; set; }
    public DateTime? ExpirationDate { get; set; }

    public static GameAccessCodeDto FromEntity(GameAccessCode GameAccessCode)
    {

        return new GameAccessCodeDto()
        {
            GameAccessCodeId = GameAccessCode.GameAccessCodeId,
            //Game = GameAccessCode.Game != null ? GameDto.FromEntity(GameAccessCode.Game)! : throw new InvalidOperationException("Game cannot be null."),
            GameId = GameAccessCode.GameId,
            IsActive = GameAccessCode.IsActive,
            UsageLimit = GameAccessCode.UsageLimit,
            TimeUsed = GameAccessCode.TimeUsed,
            ExpirationDate = GameAccessCode.ExpirationDate,
            //GameUserAccesses = GameAccessCode.GameUserAccesses.Select(GameUserAccessDto.FromEntity).ToList(),
        };
    }


}
