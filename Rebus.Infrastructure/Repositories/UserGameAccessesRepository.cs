using Microsoft.EntityFrameworkCore;
using Rebus.Domain.Entities;
using Rebus.Domain.Repositories;
using Rebus.Infrastructure.Persistance;

namespace Rebus.Infrastructure.Repositories;

internal class UserGameAccessesRepository(RebusDbContext dbContext)
    : IUserGameAccessesRepository
{
    public async Task<IEnumerable<UserGameAccess>> GetAllAsync()
    {
        var userGameAccesses = await dbContext.UserGameAccesses
           .Include(uga => uga.User)
           .Include(uga => uga.Game)
           .ToListAsync();
        return userGameAccesses;
    }

    public async Task<UserGameAccess?> GetByIdAsync(int id)
    {
        var userGameAccesses = await dbContext.UserGameAccesses
            .Include(uga => uga.User)
            .Include(uga => uga.Game)
            .FirstOrDefaultAsync(x => x.UserId == id);
        return userGameAccesses;
    }
}
