using Microsoft.Extensions.Logging;
using Rebus.Application.Users.Dtos;
using Rebus.Domain.Repositories;

namespace Rebus.Application.Users;

internal class UsersService(IUsersRepository usersRepository,
    ILogger<UsersService> logger) : IUsersService
{
    public async Task<IEnumerable<UserDto>> GetAllUsers()
    {
        logger.LogInformation("Getting all users");
        var users = await usersRepository.GetAllAsync();

        var usersDto = users.Select(UserDto.FromEntity);
        return usersDto!;
    }

    public async Task<UserDto?> GetById(int id)
    {
        logger.LogInformation($"Getting user with id {id}");
        var user = await usersRepository.GetByIdAsync(id);
        var userDto = UserDto.FromEntity(user);

        return userDto;
    }
}
