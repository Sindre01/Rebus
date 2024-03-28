namespace Rebus.Domain.Entities;
public class Game
{
    public int GameId { get; set; }
    public string GameName { get; set; } = string.Empty;
    public string? GameDescription { get; set; }
    public DateTime? DateCreated { get; set; }


}


