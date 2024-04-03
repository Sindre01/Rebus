using MediatR;
using Rebus.Application.Users.Dtos;

namespace Rebus.Application.Users.Queries.GetUserById;

public class GetUserByIdQuery(int id) : IRequest<UserDto?>
{
    public int Id { get; } = id;
}
