namespace Rebus.Domain.Entities;
public class Role
{
    public int RoleId { get; set; }
    public string RoleName { get; set; } = string.Empty;
    public string? RoleDescription { get; set; }
    public ICollection<GameCreator> GameCreators { get; set; } = new List<GameCreator>(); // Collection navigation containing dependents
}

