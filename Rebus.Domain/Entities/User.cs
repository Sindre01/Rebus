using Microsoft.AspNetCore.Identity;

namespace Rebus.Domain.Entities;

public class User : IdentityUser
{
    public DateOnly? DateOfBirth { get; set; }
    public string? Nationality { get; set; }

    public List<UserGameAccess> UserGameAccesses { get; set; } = [];
    public List<UserGameHistory> UserGameHistories { get; set; } = [];
    public List<GameCreator> GameCreators { get; set; } = [];
    public DateTime? DateJoined { get; set; }
    public bool IsLoggedIn { get; set; }
    public Location? Location { get; set; }
}
