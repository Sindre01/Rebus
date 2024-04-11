using AutoMapper;
using Microsoft.Extensions.Logging;
using Rebus.Domain.Repositories;

namespace Rebus.Application.UserGameAccesses;

internal class UserGameAccessesService(IUserGameAccessesRepository UserGameAccessesRepository,
    ILogger<UserGameAccessesService> logger,
    IMapper mapper) : IUserGameAccessesService
{
    public async Task<IEnumerable<UserGameAccessDto>> GetAllUserGameAccesses()
    {
        logger.LogInformation("Getting all accesses for all users");
        var userGameAccesses = await UserGameAccessesRepository.GetAllAsync();
        var userGameAccessesDto = mapper.Map<IEnumerable<UserGameAccessDto>>(userGameAccesses);
        return userGameAccessesDto!;
    }
    public async Task<UserGameAccessDto?> GetById(int id)
    {
        logger.LogInformation($"Getting accesses for user with id {id}");
        var userGameAccesses = await UserGameAccessesRepository.GetByIdAsync(id);
        var userGameAccessesDto = mapper.Map<UserGameAccessDto>(userGameAccesses);
        return userGameAccessesDto;
    }

}
