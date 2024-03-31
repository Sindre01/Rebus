using Microsoft.EntityFrameworkCore;
using Rebus.Domain.Entities;
using Rebus.Domain.Repositories;
using Rebus.Infrastructure.Persistance;

namespace Rebus.Infrastructure.Repositories;

internal class GameUserAccessesRepository(RebusDbContext dbContext)
    : IGameUserAccessesRepository
{
    public async Task<IEnumerable<GameUserAccess>> GetAllAsync()
    {
        var gameUserAccesses = await dbContext.GameUserAccesses
           .Include(gua => gua.User)
           .Include(gua => gua.GameAccessCode)
                .ThenInclude(gac => gac.Game)
           .ToListAsync();
        return gameUserAccesses;
    }

    public async Task<GameUserAccess?> GetByIdAsync(int id)
    {
        var gameUserAccesses = await dbContext.GameUserAccesses
            .Include(gua => gua.User)
            .Include(gua => gua.GameAccessCode)
                .ThenInclude(gac => gac.Game)
            .FirstOrDefaultAsync(x => x.UserId == id);
        return gameUserAccesses;
    }
}
