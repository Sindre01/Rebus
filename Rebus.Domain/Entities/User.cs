namespace Rebus.Domain.Entities;
public class User
{
    public int UserId { get; set; }
    public string UserName { get; set; } = default!;
    public Location? Location { get; set; }
    public string? Email { get; set; }
    public string? FullName { get; set; }
    public DateTime? DateJoined { get; set; }
    public bool? isAnonymous { get; set; }

}
