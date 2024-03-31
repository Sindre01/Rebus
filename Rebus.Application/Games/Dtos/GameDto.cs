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
    public GameAccessCodeDto? GameAccessCode { get; set; }
    public List<GameCreatorDto> GameCreators { get; set; } = [];
    public string? GameDescription { get; set; }
    public DateTime? DateCreated { get; set; }
    //public List<UserGameHistoryDto> UserGameHistories { get; set; } = [];

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
           GameAccessCode = Game.GameAccessCode != null ? GameAccessCodeDto.FromEntity(Game.GameAccessCode)! : throw new InvalidOperationException("GameAccessCode cannot be null."),
           GameCreators = Game.GameCreators.Select(GameCreatorDto.FromEntity).ToList()
            

        };
    }

}


