namespace Rebus.Domain.Entities;
public class UserAccess
{
    public int UserAccessId { get; set; }
    public int UserId { get; set; }
    public int AccessCodeID { get; set; }
    public DateTime AccessTime { get; set; }
}
