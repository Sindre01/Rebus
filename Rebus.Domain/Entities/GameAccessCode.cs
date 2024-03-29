namespace Rebus.Domain.Entities;
public class GameAccessCode
{
    public int GameAccessCodeId { get; set; }
    public Game Game { get; set; } = new Game();
    public int GameId { get; set; }
    public ICollection<GameUserAccess>? GameUserAccesses { get; }
    public int? UsageLimit { get; set; }
    public int? TimeUsed { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public bool? isActive { get; set; }


}
