using Rebus.Application.Games.Dtos;
using Rebus.Application.Roles.Dtos;
using Rebus.Application.UserGameHistories.Dtos;
using Rebus.Application.Users.Dtos;
using Rebus.Domain.Entities;

namespace Rebus.Application.GameCreators.Dtos;
public class GameCreatorDto
{
    public int GameCreatorId { get; set; }
    public DateTime StartTime { get; set; }
    public UserDto User { get; set; } = null!; // Required reference navigation to principal
    public GameDto Game { get; set; } = null!; // Required reference navigation to principal
    public RoleDto Role { get; set; } = null!; // Required reference navigation to principal

    public static GameCreatorDto FromEntity(GameCreator GameCreator)
    {
        return new GameCreatorDto()
        {
            GameCreatorId = GameCreator.GameCreatorId,
            StartTime = GameCreator.StartTime,
            User = GameCreator.User != null ? UserDto.FromEntity(GameCreator.User)! : throw new InvalidOperationException("User cannot be null."),
            Game = GameCreator.Game != null ? GameDto.FromEntity(GameCreator.Game)! : throw new InvalidOperationException("Game cannot be null."),
            Role = GameCreator.Role != null ? RoleDto.FromEntity(GameCreator.Role)! : throw new InvalidOperationException("Role cannot be null."),
        };
    }
}