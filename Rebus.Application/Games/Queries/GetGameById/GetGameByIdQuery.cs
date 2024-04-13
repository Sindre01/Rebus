using MediatR;
using Rebus.Application.Games.Dtos;

namespace Rebus.Application.Games.Queries.GetGameById;

public class GetGameByIdQuery(int id) : IRequest<GameDto?>
{
    public int Id { get; } = id;
}
