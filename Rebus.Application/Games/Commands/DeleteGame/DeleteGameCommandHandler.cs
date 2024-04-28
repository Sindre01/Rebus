using MediatR;
using Microsoft.Extensions.Logging;
using Rebus.Domain.Repositories;

namespace Rebus.Application.Games.Commands.DeleteGame;

public class DeleteGameCommandHandler(ILogger<DeleteGameCommandHandler> logger,
    IGamesRepository gamesRepository) : IRequestHandler<DeleteGameCommand, bool>
{
    public async Task<bool> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting game with id : {request.Id}", request.Id);
        var games = await gamesRepository.GetByIdAsync(request.Id);
        if (games == null)
        {
            return false;
        }
        await gamesRepository.Delete(games);
        return true;
    }
}
