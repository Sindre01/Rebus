using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Rebus.Domain.Entities;
using Rebus.Domain.Repositories;

namespace Rebus.Application.Users.Commands.CreateUser;

public class CreateUserCommandHandler(ILogger<CreateUserCommandHandler> logger,
    IMapper mapper,
    IUsersRepository usersRepository) : IRequestHandler<CreateUserCommand, int>
{
    public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating a new user");

        var user = mapper.Map<User>(request);
        int id = await usersRepository.Create(user);
        return id;
    }
}

