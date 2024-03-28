namespace Rebus.Domain.Entities;
public class Role
{
    public int RoleId { get; set; }
    public string RoleName { get; set; } = string.Empty;
    public string? RoleDescription { get; set; }
}

