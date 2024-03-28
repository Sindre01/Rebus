namespace Rebus.Domain.Entities;
public class Location
{
    public int locationId { get; set; }
    public string? latitude { get; set; }
    public string? longitude { get; set; }
    public string? state { get; set; }
    public string? city { get; set; }
    public string? street { get; set; }
    public string? postalCode { get; set; }
}

