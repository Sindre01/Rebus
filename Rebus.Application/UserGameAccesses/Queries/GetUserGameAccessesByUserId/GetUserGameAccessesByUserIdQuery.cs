using MediatR;
using Rebus.Application.UserGameAccesses.Dtos;

namespace Rebus.Application.UserGameAccesses.Queries.GetUserGameAccessById;

public class GetUserGameAccessesByUserIdQuery(int id) : IRequest<IEnumerable<UserGameAccessDto>>
{
    public int Id { get; } = id;
}
