using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Rebus.Application.UserGameAccesses.Dtos;
using Rebus.Domain.Repositories;

namespace Rebus.Application.UserGameAccesses.Queries.GetUserGameAccessById;


public class GetUserGameAccessesByUserIdQueryHandler(ILogger<GetUserGameAccessesByUserIdQueryHandler> logger,
    IMapper mapper,
    IUserGameAccessesRepository userGameAccessesRepository) : IRequestHandler<GetUserGameAccessesByUserIdQuery, IEnumerable<UserGameAccessDto>>
{
    public async Task<IEnumerable<UserGameAccessDto>> Handle(GetUserGameAccessesByUserIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting userGameAccess for User with id {UserId}", request.Id);
        var userGameAccesses = await userGameAccessesRepository.GetByUserIdAsync(request.Id);
        var userGameAccessesDto = mapper.Map<IEnumerable<UserGameAccessDto>>(userGameAccesses);
        return userGameAccessesDto;
    }
}

