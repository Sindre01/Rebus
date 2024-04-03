using Microsoft.EntityFrameworkCore;
using Rebus.Domain.Entities;
using Rebus.Domain.Repositories;
using Rebus.Infrastructure.Persistance;

namespace Rebus.Infrastructure.Repositories;

internal class UsersRepository(RebusDbContext dbContext)
    : IUsersRepository
{
    public async Task<int> Create(User entity)
    {
        dbContext.Users.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.UserId;
    }

    public async Task Delete(User entity)
    {
        dbContext.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        var users = await dbContext.Users
            .ToListAsync();
        return users;
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        var user = await dbContext.Users
            .FirstOrDefaultAsync(x => x.UserId == id);
        return user;
    }
}
