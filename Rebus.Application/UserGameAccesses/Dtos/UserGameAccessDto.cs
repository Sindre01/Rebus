using Rebus.Application.Games.Dtos;
using Rebus.Application.Users.Dtos;

namespace Rebus.Application.UserGameAccesses.Dtos;
public class UserGameAccessDto
{
    public int GameUserAccessId { get; set; }
   // public UserDto User { get; set; } = null!; No need to expose userInfo
    public int UserId { get; set; } 
    public GameDto Game { get; set; } = null!;
    public DateTime AccessTime { get; set; }

}
