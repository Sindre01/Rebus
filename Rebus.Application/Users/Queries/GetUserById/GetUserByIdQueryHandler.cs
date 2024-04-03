using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Rebus.Application.Users.Dtos;
using Rebus.Domain.Repositories;

namespace Rebus.Application.Users.Queries.GetUserById;

public class GetUserByIdQueryHandler(ILogger<GetUserByIdQueryHandler> logger,
    IMapper mapper,
    IUsersRepository usersRepository) : IRequestHandler<GetUserByIdQuery, UserDto?>
{
    public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation($"Getting user with id {request.Id}");
        var user = await usersRepository.GetByIdAsync(request.Id);
        var userDto = mapper.Map<UserDto?>(user);
        return userDto;
    }
}
