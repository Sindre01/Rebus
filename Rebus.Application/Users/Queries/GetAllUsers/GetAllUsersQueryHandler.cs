using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Rebus.Application.Users.Dtos;
using Rebus.Domain.Repositories;

namespace Rebus.Application.Users.Queries.GetAllUsers;

public class GetAllUsersQueryHandler(ILogger<GetAllUsersQueryHandler> logger,
    IMapper mapper,
    IUsersRepository usersRepository) : IRequestHandler<GetAllUsersQuery, IEnumerable<UserDto>>
{
    public async Task<IEnumerable<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all users");
        var users = await usersRepository.GetAllAsync();
        var usersDto = mapper.Map<IEnumerable<UserDto>>(users);
        return usersDto!;
    }
}
