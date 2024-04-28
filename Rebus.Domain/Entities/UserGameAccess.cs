namespace Rebus.Domain.Entities;
public class UserGameAccess
{
    public int UserGameAccessId { get; set; }
    public User User { get; set; } = null!; // Required reference navigation to principal
    public string UserId { get; set; } // Required foreign key property
    public Game Game{ get; set; } = null!; // Required reference navigation to principal
    public int GameId { get; set; } // Required foreign key property
    public DateTime AccessTime { get; set; }
}
