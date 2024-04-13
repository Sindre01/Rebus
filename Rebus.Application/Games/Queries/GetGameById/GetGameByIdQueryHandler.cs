using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Rebus.Application.Games.Dtos;
using Rebus.Application.Users.Dtos;
using Rebus.Application.Users.Queries.GetUserById;
using Rebus.Domain.Repositories;

namespace Rebus.Application.Games.Queries.GetGameById;


public class GetGameByIdQueryHandler(ILogger<GetGameByIdQueryHandler> logger,
    IMapper mapper,
    IGamesRepository gamesRepository) : IRequestHandler<GetGameByIdQuery, GameDto?>
{
    public async Task<GameDto?> Handle(GetGameByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting user with id {UserId}", request.Id);
        var game = await gamesRepository.GetByIdAsync(request.Id);
        var gameDto = mapper.Map<GameDto?>(game);
        return gameDto;
    }
}

