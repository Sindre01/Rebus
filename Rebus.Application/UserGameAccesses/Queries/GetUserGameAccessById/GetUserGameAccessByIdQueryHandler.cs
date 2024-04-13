using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Rebus.Application.UserGameAccesses.Dtos;
using Rebus.Domain.Repositories;

namespace Rebus.Application.UserGameAccesses.Queries.GetUserGameAccessById;


public class GetUserGameAccessByIdQueryHandler(ILogger<GetUserGameAccessByIdQueryHandler> logger,
    IMapper mapper,
    IUserGameAccessesRepository userGameAccessesRepository) : IRequestHandler<GetUserGameAccessByIdQuery, UserGameAccessDto?>
{
    public async Task<UserGameAccessDto?> Handle(GetUserGameAccessByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting userGameAccess with id {UserGameAccessId}", request.Id);
        var userGameAccess = await userGameAccessesRepository.GetByIdAsync(request.Id);
        var userGameAccessDto = mapper.Map<UserGameAccessDto?>(userGameAccess);
        return userGameAccessDto;
    }
}

