using MediatR;
using Microsoft.Extensions.Logging;
using Rebus.Domain.Repositories;

namespace Rebus.Application.UserGameAccesses.Commands.DeleteUserGameAccess;

public class DeleteUserGameAccessCommandHandler(ILogger<DeleteUserGameAccessCommandHandler> logger,
    IUserGameAccessesRepository userGameAccessesRepository) : IRequestHandler<DeleteUserGameAccessCommand, bool>
{
    public async Task<bool> Handle(DeleteUserGameAccessCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting userGameAccess with id : {request.Id}", request.Id);
        var userGameAccess = await userGameAccessesRepository.GetByIdAsync(request.Id);
        if (userGameAccess == null)
        {
            return false;
        }
        await userGameAccessesRepository.Delete(userGameAccess);
        return true;
    }
}
