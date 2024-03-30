using Rebus.Application.GameAccessCodes.Dtos;
using Rebus.Application.GameCreators.Dtos;
using Rebus.Application.Roles.Dtos;
using Rebus.Application.UserGameHistories.Dtos;
using Rebus.Application.Users.Dtos;
using Rebus.Domain.Entities;

namespace Rebus.Application.Games.Dtos;
public class GameDto
{
    public enum Statuses
    {
        Editing,
        Unactive,
        Active
    }
    public int GameId { get; set; }
    public string GameName { get; set; } = string.Empty;
    public Statuses Status { get; set; }
    public GameAccessCodeDto GameAccessCode { get; set; } = new();
    public List<GameCreatorDto> GameCreators { get; set; } = [];
    public string? GameDescription { get; set; }
    public DateTime? DateCreated { get; set; }
    public List<UserGameHistoryDto> UserGameHistories { get; set; } = [];

    public static GameDto? FromEntity(Game? Game)
    {
        if (Game == null) return null;
        return new GameDto()
        {
           GameId = Game.GameId,
           GameName = Game.GameName,
           GameDescription = Game.GameDescription,
           DateCreated = Game.DateCreated,
           Status = (Statuses) Game.Status,
           GameAccessCode = GameAccessCodeDto.FromEntity(Game.GameAccessCode),
           GameCreators = Game.GameCreators.Select(GameCreatorDto.FromEntity).ToList()
            

        };
    }

}


