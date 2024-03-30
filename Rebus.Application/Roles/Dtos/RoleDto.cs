using Rebus.Application.GameCreators.Dtos;
using Rebus.Application.Games.Dtos;
using Rebus.Application.Users.Dtos;
using Rebus.Domain.Entities;

namespace Rebus.Application.Roles.Dtos;
public class RoleDto
{
    public int RoleId { get; set; }
    public string RoleName { get; set; } = string.Empty;
    public string? RoleDescription { get; set; }
    public List<GameCreatorDto> GameCreators { get; set; } = []; // Collection navigation containing dependents
    public static RoleDto FromEntity(Role Role)
    {
        return new RoleDto()
        {
            RoleId = Role.RoleId,
            RoleName = Role.RoleName,
            RoleDescription = Role.RoleDescription,
            GameCreators = Role.GameCreators.Select(GameCreatorDto.FromEntity).ToList()
        };
    }
}


