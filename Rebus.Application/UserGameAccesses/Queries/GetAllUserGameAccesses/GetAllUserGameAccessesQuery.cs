using MediatR;
using Rebus.Application.UserGameAccesses.Dtos;

namespace Rebus.Application.UserGameAccesses.Queries.GetAllUserGameAccesses;

public class GetAllUserGameAccessesQuery : IRequest<IEnumerable<UserGameAccessDto>>
{
}
