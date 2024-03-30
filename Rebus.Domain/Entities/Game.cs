namespace Rebus.Domain.Entities;

public class Game
{
    public enum Statuses
    {
        Editing,
        Unactive,
        Active
    }

    public int GameId { get; set; }
    public GameAccessCode? GameAccessCode { get; set; }
    public List<UserGameHistory> UserGameHistories { get; set; } = [];
    public List<GameCreator> GameCreators { get; set; } = [];

    public string GameName { get; set; } = string.Empty;
    public string? GameDescription { get; set; }
    public DateTime? DateCreated { get; set; }
    public Statuses Status { get; set; }


}


