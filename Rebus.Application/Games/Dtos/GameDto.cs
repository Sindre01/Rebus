using Rebus.Application.GameAccessCodes.Dtos;
using Rebus.Application.GameCreators.Dtos;

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

}


