using Rebus.Domain.Entities;
using Rebus.Infrastructure.Persistance;

namespace Rebus.Infrastructure.Seeders;

internal class RebusSeeder(RebusDbContext dbContext) : IRebusSeeder
{
    public async Task Seed()
{
        if (!dbContext.Games.Any())
        {

/*            var user = new User { UserName = "Example User" };
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();

            var game = new Game { GameName = "Example Game", AccessCode = "1234"};
            dbContext.Games.Add(game);
            await dbContext.SaveChangesAsync();

            var userGameAccess = new UserGameAccess { AccessTime = DateTime.UtcNow, User = user, Game = game};
            dbContext.UserGameAccesses.Add(userGameAccess);
            await dbContext.SaveChangesAsync();*/
    
        }

    }


}
