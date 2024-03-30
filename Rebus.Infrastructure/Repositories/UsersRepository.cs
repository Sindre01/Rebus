using Microsoft.EntityFrameworkCore;
using Rebus.Domain.Entities;
using Rebus.Domain.Repositories;
using Rebus.Infrastructure.Persistance;

namespace Rebus.Infrastructure.Repositories;

internal class UsersRepository(RebusDbContext dbContext)
    : IUsersRepository
{
    public async Task<IEnumerable<User>> GetAllAsync()
    {
        var users = await dbContext.Users
          //  .Include(u => u.GameUserAccesses)
           // .Include(u => u.GameCreators)
            //.Include(u => u.UserGameHistories)
            //.AsSplitQuery()
            .ToListAsync();
        return users;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        var user = await dbContext.Users
          //  .Include(u => u.GameUserAccesses)
            // .Include(u => u.GameCreators)
            //.Include(u => u.UserGameHistories)
            //.AsSplitQuery()
            .FirstOrDefaultAsync(x => x.UserId == id);
        return user;
    }
}
