using AutoMapper;
using Microsoft.Extensions.Logging;
using Rebus.Application.GameUserAccesses;
using Rebus.Application.GameUserAccesses.Dtos;
using Rebus.Application.Users.Dtos;
using Rebus.Domain.Entities;
using Rebus.Domain.Repositories;

namespace Rebus.Application.GameUserAccesses;

internal class GameUserAccessesService(IGameUserAccessesRepository GameUserAccessesRepository,
    ILogger<GameUserAccessesService> logger,
    IMapper mapper) : IGameUserAccessesService
{
    public async Task<IEnumerable<GameUserAccessDto>> GetAllGameUserAccesses()
    {
        logger.LogInformation("Getting all accesses for all users");
        var gameUserAccesses = await GameUserAccessesRepository.GetAllAsync();
        var gameUserAccessesDto = mapper.Map<IEnumerable<GameUserAccessDto>>(gameUserAccesses);
        return gameUserAccessesDto!;
    }
    public async Task<GameUserAccessDto?> GetById(int id)
    {
        logger.LogInformation($"Getting accesses for user with id {id}");
        var gameUserAccesses = await GameUserAccessesRepository.GetByIdAsync(id);
        var gameUserAccessesDto = mapper.Map<GameUserAccessDto>(gameUserAccesses);
        return gameUserAccessesDto;
    }

}
