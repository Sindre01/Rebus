using Rebus.Domain.Entities;
using Rebus.Infrastructure.Persistance;

namespace Rebus.Infrastructure.Seeders;

internal class RebusSeeder(RebusDbContext dbContext) : IRebusSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Users.Any())
            {
                var users = GetUsers();
                dbContext.Users.AddRange(users);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<User> GetUsers()
    {
        var user = new User
        {
            UserName = "Sindre",
            isLoggedIn = false,
        };


        var userAccess = new GameUserAccess
        {
            AccessTime = DateTime.UtcNow,
            User = user // Set the User navigation property
        };


        var accessCode = new GameAccessCode
        {
            IsActive = true,
        };

        var game = new Game
        {
            GameName = "TestGame",
            Status = 0,


        };

        user.GameUserAccesses = new List<GameUserAccess> { userAccess };
        accessCode.Game = game;
        game.GameAccessCode = accessCode;
        userAccess.GameAccessCode = accessCode;

        return new List<User> { user };
    }
}
