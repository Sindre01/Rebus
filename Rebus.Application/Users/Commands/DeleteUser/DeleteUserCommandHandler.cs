using MediatR;
using Microsoft.Extensions.Logging;
using Rebus.Domain.Repositories;

namespace Rebus.Application.Users.Commands.DeleteUser;

public class DeleteUserCommandHandler(ILogger<DeleteUserCommandHandler> logger,
    IUsersRepository usersRepository) : IRequestHandler<DeleteUserCommand, bool>
{
    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting user with id : {request.Id}", request.Id);
        var user = await usersRepository.GetByIdAsync(request.Id);
        if (user == null)
        {
            return false;
        }
        await usersRepository.Delete(user);
        return true;
    }
}
