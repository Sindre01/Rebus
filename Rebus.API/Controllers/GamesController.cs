using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rebus.Application.Games.Commands.CreateGame;
using Rebus.Application.Games.Commands.DeleteGame;
using Rebus.Application.Games.Dtos;
using Rebus.Application.Games.Queries.GetAllGames;
using Rebus.Application.Games.Queries.GetGameById;

namespace Rebus.API.Controllers;

[ApiController]
[Route("api/games")]
public class GamesController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<GameDto>>> GetAll()
    {
        var games = await mediator.Send(new GetAllGamesQuery());
        return Ok(games);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GameDto?>> GetById([FromRoute] int id)
    {
        var game = await mediator.Send(new GetGameByIdQuery(id));

        if (game is null)
            return NotFound();

        return Ok(game);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteGame([FromRoute] int id)
    {
        var isDeleted = await mediator.Send(new DeleteGameCommand(id));

        if (isDeleted)
            return NoContent();

        return NotFound();
    }

/*    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateGame([FromRoute] int id, UpdateGameCommand command)
    {
        command.Id = id;
        var isUpdated = await mediator.Send(command);

        if (isUpdated)
            return NoContent();

        return NotFound();
    }*/

    [HttpPost]
    public async Task<IActionResult> CreateGame(CreateGameCommand command)
    {
        int id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }


}
