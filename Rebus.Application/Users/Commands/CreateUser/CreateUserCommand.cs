
using MediatR;

namespace Rebus.Application.Users.Commands.CreateUser;

public class CreateUserCommand : IRequest<int>
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
