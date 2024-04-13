﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Rebus.Domain.Entities;
using Rebus.Domain.Exceptions;
using Rebus.Domain.Repositories;

namespace Rebus.Application.UserGameAccesses.Commands.CreateUserGameAccess;

public class CreateUserGameAccessCommandHandler(ILogger<CreateUserGameAccessCommand> logger,
    IUsersRepository usersRepository,
    IGamesRepository gamesRepository,
    IUserGameAccessesRepository userGameAccessesRepository,
    IMapper mapper) : IRequestHandler<CreateUserGameAccessCommand>
{
    public async Task Handle(CreateUserGameAccessCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new UserGameAccess: {@UserGameAccessRequest}", request);
        var user = await usersRepository.GetByIdAsync(request.UserId);
        if (user == null) throw new NotFoundException(nameof(User), request.UserId.ToString());

        var game = await gamesRepository.GetByIdAsync(request.GameId);
        if (game == null) throw new NotFoundException(nameof(Game), request.GameId.ToString());

        var userGameAccess = mapper.Map<UserGameAccess>(request);

        await userGameAccessesRepository.Create(userGameAccess);


    }
}
