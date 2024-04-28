namespace Rebus.Domain.Entities;
public class UserGameHistory
{
    public int UserGameHistoryId { get; set; }
    public User User { get; set; } = null!;
    public string UserId { get; set; }
    public Role Role { get; set; } = null!;
    public int RoleId { get; set; }
    public Game Game { get; set; } = null!;
    public int GameId { get; set; }
    public DateTime AccessStart { get; set; }
    public DateTime AccessEnd { get; set; }

}
