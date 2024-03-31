using Microsoft.EntityFrameworkCore;
using Rebus.Domain.Entities;
using Rebus.Infrastructure.Persistance;

namespace Rebus.Infrastructure.Seeders;

internal class RebusSeeder(RebusDbContext dbContext) : IRebusSeeder
{
    public async Task Seed()
{
        if (!dbContext.Games.Any())
        {

            var user = new User { UserName = "ExampleUser" };
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();

            var game = new Game { GameName = "Example Game"};
            dbContext.Games.Add(game);
            await dbContext.SaveChangesAsync();

            var accessCode = new GameAccessCode { IsActive = true, Game = game};
       
            dbContext.GameAccessCodes.Add(accessCode);
            await dbContext.SaveChangesAsync();

            var gameUserAccess = new GameUserAccess { AccessTime = DateTime.UtcNow, User = user, GameAccessCode = accessCode};
            dbContext.GameUserAccesses.Add(gameUserAccess);
            await dbContext.SaveChangesAsync();
     

        }

    }


}
