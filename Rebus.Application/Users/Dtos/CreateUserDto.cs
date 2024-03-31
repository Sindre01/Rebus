using Rebus.Domain.Entities;

namespace Rebus.Application.Users.Dtos;

public class CreateUserDto
{
    public int UserId { get; set; }
    public string UserName { get; set; } = default!;
    public bool IsLoggedIn { get; set; }

    public string? FullName { get; set; }
    public DateTime? DateJoined { get; set; }
    public string? Email { get; set; }

    public static UserDto? FromEntity(User? user)
    {
        if (user == null) return null;

        return new UserDto()
        {
            UserId = user.UserId,
            UserName = user.UserName,
            IsLoggedIn = user.IsLoggedIn,
            Latitude = user.Location?.Latitude,
            Longitude = user.Location?.Longitude,
            City = user.Location?.City,
            Street = user.Location?.Street,
            PostalCode = user.Location?.PostalCode,
            DateJoined = user.DateJoined,
            FullName = user.FullName,
            //GameCreators = user.GameCreators.Select(GameCreatorDto.FromEntity).ToList(),
            //UserGameHistories = user.UserGameHistories.Select(UserGameHistoryDto.FromEntity).ToList(),
            //GameUserAccesses = user.GameUserAccesses.Select(GameUserAccessDto.FromEntity).ToList()
        };
    }
}
