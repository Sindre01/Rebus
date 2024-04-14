using Microsoft.EntityFrameworkCore;
using Rebus.Domain.Entities;
using Rebus.Domain.Repositories;
using Rebus.Infrastructure.Persistance;

namespace Rebus.Infrastructure.Repositories;

internal class UserGameAccessesRepository(RebusDbContext dbContext)
    : IUserGameAccessesRepository
{
    public async Task<int> Create(UserGameAccess entity)
    {
        dbContext.UserGameAccesses.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.UserGameAccessId;
    }

    public async Task Delete(UserGameAccess entity)
    {

        dbContext.Remove(entity);
        await dbContext.SaveChangesAsync();
   
    }

    public async Task Delete(IEnumerable<UserGameAccess> entities)
    {
        dbContext.UserGameAccesses.RemoveRange(entities);
        await dbContext.SaveChangesAsync();
    }

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
            .FirstOrDefaultAsync(x => x.UserGameAccessId == id);
        return userGameAccesses;
    }

    public async Task<IEnumerable<UserGameAccess>> GetByUserIdAsync(int id)
    {
        var userGameAccesses = await dbContext.UserGameAccesses
            .Include(uga => uga.User)
            .Include(uga => uga.Game)
            .Where(x => x.UserId == id)
            .ToListAsync();
        return userGameAccesses;
    }

    public Task SaveChanges()
        => dbContext.SaveChangesAsync();
}
