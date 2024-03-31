namespace Rebus.Application.GameAccessCodes.Dtos;
public class GameAccessCodeDto
{
    public int GameAccessCodeId { get; set; }
    //public GameDto Game { get; set; } = null!;
    public int GameId { get; set; }
    public bool IsActive { get; set; }
    //public List<GameUserAccessDto> GameUserAccesses { get; set; } = [];
    public int? UsageLimit { get; set; }
    public int? TimeUsed { get; set; }
    public DateTime? ExpirationDate { get; set; }
}
