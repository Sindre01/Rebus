using Rebus.Application.GameCreators.Dtos;
using Rebus.Application.GameUserAccesses.Dtos;
using Rebus.Application.UserGameHistories.Dtos;
using Rebus.Domain.Entities;

namespace Rebus.Application.Users.Dtos;

public  class UserDto
{
    public int UserId { get; set; }
    public string UserName { get; set; } = default!;
    public bool IsLoggedIn { get; set; }

    //Location
    public string? Latitude { get; set; }
    public string? Longitude { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public string? PostalCode { get; set; }

    //public List<GameUserAccessDto> GameUserAccesses { get; set; } = [];
    //public List<UserGameHistoryDto> UserGameHistories { get; set; } = [];
    //public List<GameCreatorDto> GameCreators { get; set; } = [];
    public string? FullName { get; set; }
    public DateTime? DateJoined { get; set; }
}
