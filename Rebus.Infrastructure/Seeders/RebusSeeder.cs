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
        List<User> users = [
            new()
            {
                UserName = "Sindre",
                isLoggedIn = false,
            }
            ];
        return users;
    }
}
