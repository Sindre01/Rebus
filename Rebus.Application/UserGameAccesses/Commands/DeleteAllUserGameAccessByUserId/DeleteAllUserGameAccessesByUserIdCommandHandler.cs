using MediatR;
using Microsoft.Extensions.Logging;
using Rebus.Domain.Exceptions;
using Rebus.Domain.Repositories;

namespace Rebus.Application.UserGameAccesses.Commands.DeleteAllUserGameAccessByUserId;

public class DeleteAllUserGameAccessesByUserIdCommandHandler(ILogger<DeleteAllUserGameAccessesByUserIdCommandHandler> logger,
    IUserGameAccessesRepository userGameAccessesRepository) : IRequestHandler<DeleteAllUserGameAccessesByUserIdCommand>
{
    public async Task Handle(DeleteAllUserGameAccessesByUserIdCommand request, CancellationToken cancellationToken)
    {
        logger.LogWarning("Removing all UserGameAccesses for {userId}", request.UserId);

        var userGameAccesses = await userGameAccessesRepository.GetByUserIdAsync(request.UserId);
        if (!userGameAccesses.Any() ) throw new NotFoundException(nameof(userGameAccesses) + " for user ", request.UserId.ToString());
        await userGameAccessesRepository.Delete(userGameAccesses);
    }
}
