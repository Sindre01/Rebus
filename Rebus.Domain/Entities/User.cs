namespace Rebus.Domain.Entities;
public class User
{
    public int UserId { get; set; }
    public string UserName { get; set; } = default!;
    public bool isLoggedIn { get; set; }
    public Location? Location { get; set; }

    public ICollection<GameUserAccess>? GameUserAccesses { get; set; }
    public ICollection<UserGameHistory>? UserGameHistories { get; set; }
    public ICollection<GameCreator>? GameCreators { get; set; }
    public string? Email { get; set; }
    public string? FullName { get; set; }
    public DateTime? DateJoined { get; set; }
    

}
