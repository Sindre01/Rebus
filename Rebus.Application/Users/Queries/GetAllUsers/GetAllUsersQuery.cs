using MediatR;
using Rebus.Application.Users.Dtos;

namespace Rebus.Application.Users.Queries.GetAllUsers;

public class GetAllUsersQuery : IRequest<IEnumerable<UserDto>>
{

}
