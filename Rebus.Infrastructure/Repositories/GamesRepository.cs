using Microsoft.EntityFrameworkCore;
using Rebus.Domain.Entities;
using Rebus.Domain.Repositories;
using Rebus.Infrastructure.Persistance;

namespace Rebus.Infrastructure.Repositories;

internal class GamesRepository(RebusDbContext dbContext)
    : IGamesRepository
{
    public async Task<int> Create(Game entity)
    {
        dbContext.Games.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.GameId;
    }

    public async Task Delete(Game entity)
    {
        dbContext.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        var games = await dbContext.Games
            .ToListAsync();
        return games;
    }

    public async Task<Game?> GetByIdAsync(int id)
    {
        var game = await dbContext.Games
            .FirstOrDefaultAsync(x => x.GameId == id);
        return game;
    }

    public Task SaveChanges()
        => dbContext.SaveChangesAsync();
}
