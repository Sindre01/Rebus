namespace Rebus.Domain.Entities;
public class GameUserAccess
{
    public int GameUserAccessId { get; set; }
    public User User { get; set; } = null!; // Required reference navigation to principal
    public int UserId { get; set; } // Required foreign key property
    public GameAccessCode GameAccessCode { get; set; } = null!; // Required reference navigation to principal
    public int GameAccessCodeId { get; set; } // Required foreign key property
    public DateTime AccessTime { get; set; }
}
