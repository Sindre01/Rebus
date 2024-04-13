using MediatR;
using Rebus.Application.Games.Dtos;

namespace Rebus.Application.Games.Queries.GetAllGames;

public class GetAllGamesQuery : IRequest<IEnumerable<GameDto>>
{
}
