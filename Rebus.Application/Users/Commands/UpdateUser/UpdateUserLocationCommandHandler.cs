using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Rebus.Domain.Repositories;

namespace Rebus.Application.Users.Commands.UpdateUser;

public class UpdateUserLocationCommandHandler(ILogger<UpdateUserLocationCommandHandler> logger,
    IUsersRepository usersRepository,
    IMapper mapper) : IRequestHandler<UpdateUserLocationCommand, bool>
{
    public async Task<bool> Handle(UpdateUserLocationCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Update user with id : {userID} with {@UpdatedUser}", request.Id, request);
        var user = await usersRepository.GetByIdAsync(request.Id);
        if (user == null)
        {
            return false;
        }
        mapper.Map(request, user);

        await usersRepository.SaveChanges();

        return true;
    }
}
