using Rebus.Application.GameCreators.Dtos;

namespace Rebus.Application.Roles.Dtos;
public class RoleDto
{
    public int RoleId { get; set; }
    public string RoleName { get; set; } = string.Empty;
    public string? RoleDescription { get; set; }
    public List<GameCreatorDto> GameCreators { get; set; } = []; // Collection navigation containing dependents
}


