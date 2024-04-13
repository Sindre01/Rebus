using MediatR;

namespace Rebus.Application.Games.Commands.CreateGame;

public class CreateGameCommand : IRequest<int>
{
/*    public enum Statuses
    {
        Editing,
        Unactive,
        Active
    }*/
    public string GameName { get; set; } = string.Empty;
   // public Statuses Status { get; set; }
    public string AccessCode { get; set; } = string.Empty;
    public int? CurrentPlayers { get; set; }
    public int? MaxPlayers { get; set; }
/*    public List<GameCreatorDto> GameCreators { get; set; } = [];
    public List<UserGameAccess> UserGameAccesses { get; set; } = [];*/
    public string? GameDescription { get; set; }
    public DateTime? DateCreated { get; set; }
    //public List<UserGameHistoryDto> UserGameHistories { get; set; } = [];
}
