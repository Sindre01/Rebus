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
        var users = await dbContext.Users.ToListAsync();
        return users;
    }
}
