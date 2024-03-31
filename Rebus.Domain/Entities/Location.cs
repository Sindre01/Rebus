namespace Rebus.Domain.Entities;
public class Location
{
    public int LocationId { get; set; }
    public string? Latitude { get; set; }
    public string? Longitude { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }
}

