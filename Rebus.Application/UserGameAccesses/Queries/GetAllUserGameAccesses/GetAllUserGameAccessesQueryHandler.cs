using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Rebus.Application.UserGameAccesses.Dtos;
using Rebus.Application.Users.Dtos;
using Rebus.Domain.Repositories;

namespace Rebus.Application.UserGameAccesses.Queries.GetAllUserGameAccesses;

public class GetAllUserGameAccessesQueryHandler(ILogger<GetAllUserGameAccessesQueryHandler> logger,
IMapper mapper,
    IUserGameAccessesRepository userGameAccessesRepository) : IRequestHandler<GetAllUserGameAccessesQuery, IEnumerable<UserGameAccessDto>>
{
    public async Task<IEnumerable<UserGameAccessDto>> Handle(GetAllUserGameAccessesQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all users");
        var userGameAccesses = await userGameAccessesRepository.GetAllAsync();
        var userGameAccessesDto = mapper.Map<IEnumerable<UserDto>>(userGameAccesses);
        return userGameAccessesDto!;
    }
}
