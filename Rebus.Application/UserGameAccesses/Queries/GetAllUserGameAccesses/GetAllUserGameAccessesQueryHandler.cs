using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Rebus.Application.UserGameAccesses.Dtos;
using Rebus.Domain.Repositories;

namespace Rebus.Application.UserGameAccesses.Queries.GetAllUserGameAccesses;

public class GetAllUserGameAccessesQueryHandler(ILogger<GetAllUserGameAccessesQueryHandler> logger,
IMapper mapper,
    IUserGameAccessesRepository userGameAccessesRepository) : IRequestHandler<GetAllUserGameAccessesQuery, IEnumerable<UserGameAccessDto>>
{
    public async Task<IEnumerable<UserGameAccessDto>> Handle(GetAllUserGameAccessesQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all userGameAccesses");
        var userGameAccesses = await userGameAccessesRepository.GetAllAsync();
        var userGameAccessesDto = mapper.Map<IEnumerable<UserGameAccessDto>>(userGameAccesses);
        return userGameAccessesDto!;
    }
}
