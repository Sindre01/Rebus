using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Rebus.Application.Games.Dtos;
using Rebus.Domain.Repositories;

namespace Rebus.Application.Games.Queries.GetAllGames;

public class GetAllGamesQueryHandler(ILogger<GetAllGamesQueryHandler> logger,
    IMapper mapper,
    IGamesRepository gamesRepository) : IRequestHandler<GetAllGamesQuery, IEnumerable<GameDto>>
{
    public async Task<IEnumerable<GameDto>> Handle(GetAllGamesQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all games");
        var games = await gamesRepository.GetAllAsync();
        var gamesDto = mapper.Map<IEnumerable<GameDto>>(games);
        return gamesDto!;
    }
}
