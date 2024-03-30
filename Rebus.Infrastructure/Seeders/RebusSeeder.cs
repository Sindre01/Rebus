using Microsoft.EntityFrameworkCore;
using Rebus.Domain.Entities;
using Rebus.Infrastructure.Persistance;

namespace Rebus.Infrastructure.Seeders;

internal class RebusSeeder(RebusDbContext dbContext) : IRebusSeeder
{
    public async Task Seed()
{
        if (!dbContext.Users.Any())
        {
            // Seed Users
            var users = new List<User>
        {
            new User
            {
                UserName = "User1",
                IsLoggedIn = true,
                // Assuming other required properties are set here...
            },
            new User
            {
                UserName = "User2",
                IsLoggedIn = false,
                // Assuming other required properties are set here...
            }
            };

            await dbContext.Users.AddRangeAsync(users);
        }
        await dbContext.SaveChangesAsync();

        if (!dbContext.Games.Any() && !dbContext.GameAccessCodes.Any())
        {
            // Create a new game
            var game = new Game
            {
                GameName = "Game1",
                // Other required properties...
            };

            // Create a new GameAccessCode and associate it with the game
            var gameAccessCode = new GameAccessCode
            {
                IsActive = true,
                Game = game, // Associate the GameAccessCode with the newly created game
                             // Other required properties...
            };

            // Optionally, associate the game with the access code
            // This step may be redundant depending on your configuration and needs
            game.GameAccessCode = gameAccessCode;

            // Add the game (and by extension, the game access code) to the context
            dbContext.Games.Add(game);

            // Since the entities are related, saving changes will persist both to the database
            await dbContext.SaveChangesAsync();
        }

        if (!dbContext.GameUserAccesses.Any())
        {
            var user = dbContext.Users.First(); // Example: getting the first user
            var accessCode = dbContext.GameAccessCodes.First(); // Example: getting the first access code

            var gameUserAccesses = new List<GameUserAccess>
        {
            new GameUserAccess
            {
                UserId = user.UserId,
                GameAccessCodeId = accessCode.GameAccessCodeId,
                AccessTime = DateTime.UtcNow,
                // Assuming other required properties are set here...
            }
            };

            await dbContext.GameUserAccesses.AddRangeAsync(gameUserAccesses);
        }

        await dbContext.SaveChangesAsync();

    }


}
