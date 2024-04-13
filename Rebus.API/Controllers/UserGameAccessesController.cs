using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rebus.Application.UserGameAccesses.Commands.CreateUserGameAccess;
using Rebus.Application.UserGameAccesses.Dtos;
using Rebus.Application.UserGameAccesses.Queries.GetAllUserGameAccesses;
using Rebus.Application.UserGameAccesses.Queries.GetUserGameAccessById;

namespace Rebus.API.Controllers;

[ApiController]
[Route("api/users")]
public class UserGameAccessesController(
    IMediator mediator) : ControllerBase
{
    [HttpGet]
    [Route("games/accesses")]
    public async Task<ActionResult<IEnumerable<UserGameAccessDto>>> GetAll()
    {
        var userGameAccess = await mediator.Send(new GetAllUserGameAccessesQuery());
        return Ok(userGameAccess);
    }

    [HttpGet("{id}/games/accesses")]
    public async Task<ActionResult<UserGameAccessDto?>> GetById([FromRoute] int id)
    {
        var gameUserAccesses = await mediator.Send(new GetUserGameAccessesByUserIdQuery(id));
        if (gameUserAccesses is null)
            return NotFound();

        return Ok(gameUserAccesses);
    }

    [HttpPost("{userId}/games/{gameId}/access")]
    public async Task<IActionResult> CreateUserGameAccess([FromRoute] int userId, [FromRoute] int gameId, CreateUserGameAccessCommand command)
    {
        command.UserId = userId;
        command.GameId = gameId;
        await mediator.Send(command);
        return Created();
    }


}