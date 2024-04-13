using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Rebus.Application.Users.Commands.CreateUser;
using Rebus.Domain.Entities;
using Rebus.Domain.Repositories;

namespace Rebus.Application.Games.Commands.CreateGame;

public class CreateGameCommandHandler(ILogger<CreateGameCommandHandler> logger,
    IMapper mapper,
    IGamesRepository gamesRepository) : IRequestHandler<CreateGameCommand, int>
{
    public async Task<int> Handle(CreateGameCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating a new game {@Game}", request);

        var game = mapper.Map<Game>(request);
        int id = await gamesRepository.Create(game);
        return id;
    }
}
