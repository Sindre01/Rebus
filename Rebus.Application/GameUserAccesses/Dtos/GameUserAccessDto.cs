using Rebus.Application.GameAccessCodes.Dtos;
using Rebus.Application.Users.Dtos;

namespace Rebus.Application.GameUserAccesses.Dtos;
public class GameUserAccessDto
{
    public int GameUserAccessId { get; set; }
    public UserDto User { get; set; } = null!; // Required reference navigation to principal
    public GameAccessCodeDto GameAccessCode { get; set; } = null!; // Required reference navigation to principal
    public DateTime AccessTime { get; set; }

}
