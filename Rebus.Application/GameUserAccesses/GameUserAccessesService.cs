using Microsoft.Extensions.Logging;
using Rebus.Application.GameUserAccesses;
using Rebus.Application.GameUserAccesses.Dtos;
using Rebus.Application.Users.Dtos;
using Rebus.Domain.Repositories;

namespace Rebus.Application.GameUserAccesses;

internal class GameUserAccessesService(IGameUserAccessesRepository GameUserAccessesRepository,
    ILogger<GameUserAccessesService> logger) : IGameUserAccessesService
{
    public async Task<IEnumerable<GameUserAccessDto>> GetAllGameUserAccesses()
    {
        logger.LogInformation("Getting all GameUserAccesses");
        var gameUserAccesses = await GameUserAccessesRepository.GetAllAsync();
        var gameUserAccessesDto = gameUserAccesses.Select(GameUserAccessDto.FromEntity);
        return gameUserAccessesDto!;
    }
    public async Task<GameUserAccessDto?> GetById(int id)
    {
        logger.LogInformation($"Getting user with id {id}");
        var gameUserAccesses = await GameUserAccessesRepository.GetByIdAsync(id);
        var gameUserAccessesDto = GameUserAccessDto.FromEntity(gameUserAccesses);

        return gameUserAccessesDto;
    }

}
