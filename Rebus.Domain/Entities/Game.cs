namespace Rebus.Domain.Entities;
public class Game
{
    public int GameId { get; set; }
    public GameAccessCode? GameAccessCode { get; set; }
    public ICollection<UserGameHistory>? UserGameHistories { get; set; }
    public ICollection<GameCreator> GameCreators { get; set; } = new List<GameCreator>();

    public string GameName { get; set; } = string.Empty;
    public string? GameDescription { get; set; }
    public DateTime? DateCreated { get; set; }


}


