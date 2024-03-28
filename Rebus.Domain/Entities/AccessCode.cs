namespace Rebus.Domain.Entities;
public class AccessCode
{
    public int AccessCodeId { get; set; }
    public Game GameId { get; set; } = new Game();
    public int? UsageLimit { get; set; }
    public int? TimeUsed { get; set; }
    public DateTime? ExpirationDate { get; set; }
    public bool? isActive { get; set; }


}
