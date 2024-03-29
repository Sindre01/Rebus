using Microsoft.Extensions.Logging;
using Rebus.Domain.Entities;
using Rebus.Domain.Repositories;

namespace Rebus.Application.Users;

internal class UsersService(IUsersRepository usersRepository,
    ILogger<UsersService> logger) : IUsersService
{
    public async Task<IEnumerable<User>> GetAllUsers()
    {
        logger.LogInformation("Getting all users");
        var users = await usersRepository.GetAllAsync();
        return users;
    }
}
