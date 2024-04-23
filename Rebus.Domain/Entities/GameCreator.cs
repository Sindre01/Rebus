namespace Rebus.Domain.Entities;
public class GameCreator
{
    public int GameCreatorId { get; set; }
    public User User { get; set; } = null!; // Required reference navigation to principal
    public string UserId { get; set; } // Required foreign key property
    public Game Game { get; set; } = null!; // Required reference navigation to principal
    public int GameId { get; set; }
    public Role Role { get; set; } = null!;
    public int RoleId { get; set; }
    
    public DateTime StartTime { get; set; }
}