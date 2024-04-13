using MediatR;
using Rebus.Application.UserGameAccesses.Dtos;

namespace Rebus.Application.UserGameAccesses.Queries.GetUserGameAccessById;

public class GetUserGameAccessByIdQuery(int id) : IRequest<UserGameAccessDto?>
{
    public int Id { get; } = id;
}
