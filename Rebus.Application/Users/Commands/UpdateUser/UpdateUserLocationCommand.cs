using MediatR;

namespace Rebus.Application.Users.Commands.UpdateUser;

public class UpdateUserLocationCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string? Latitude { get; set; }
    public string? Longitude { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }
}
