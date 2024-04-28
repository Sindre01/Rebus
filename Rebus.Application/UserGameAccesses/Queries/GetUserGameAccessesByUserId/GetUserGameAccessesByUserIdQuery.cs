using MediatR;
using Rebus.Application.UserGameAccesses.Dtos;

namespace Rebus.Application.UserGameAccesses.Queries.GetUserGameAccessById;

public class GetUserGameAccessesByUserIdQuery(string id) : IRequest<IEnumerable<UserGameAccessDto>>
{
    public string Id { get; } = id;
}
