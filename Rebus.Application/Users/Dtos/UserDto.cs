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
    public string? latitude { get; set; }
    public string? longitude { get; set; }
    public string? city { get; set; }
    public string? street { get; set; }
    public string? postalCode { get; set; }

    public List<GameUserAccessDto> GameUserAccesses { get; set; } = [];
    public List<UserGameHistoryDto> UserGameHistories { get; set; } = [];
    public List<GameCreatorDto> GameCreators { get; set; } = [];
    public string? FullName { get; set; }
    public DateTime? DateJoined { get; set; }

    public static UserDto? FromEntity(User? user)
    {
        if (user == null) return null;

        return new UserDto()
        {
            UserId = user.UserId,
            UserName = user.UserName,
            IsLoggedIn = user.IsLoggedIn,
            latitude = user.Location?.latitude,
            longitude = user.Location?.longitude,
            city = user.Location?.city,
            street = user.Location?.street,
            postalCode = user.Location?.postalCode,
            DateJoined = user.DateJoined,
            GameCreators = user.GameCreators.Select(GameCreatorDto.FromEntity).ToList(),
            UserGameHistories = user.UserGameHistories.Select(UserGameHistoryDto.FromEntity).ToList(),
            GameUserAccesses = user.GameUserAccesses.Select(GameUserAccessDto.FromEntity).ToList()
        };
    }
}
