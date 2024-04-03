using System.ComponentModel.DataAnnotations;

namespace Rebus.Application.Users.Dtos;

public class CreateUserDto
{
    public string UserName { get; set; } = default!;
    public bool IsLoggedIn { get; set; }
    public string? FullName { get; set; }
    public DateTime? DateJoined { get; set; }
    public string? Email { get; set; }

    //Location
    public string? Latitude { get; set; }
    public string? Longitude { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }

}
