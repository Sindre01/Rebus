using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rebus.Application.UserGameAccesses.Commands.CreateUserGameAccess;
using Rebus.Application.UserGameAccesses.Commands.DeleteAllUserGameAccessByUserId;
using Rebus.Application.UserGameAccesses.Dtos;
using Rebus.Application.UserGameAccesses.Queries.GetAllUserGameAccesses;
using Rebus.Application.UserGameAccesses.Queries.GetUserGameAccessById;
using Rebus.Application.Users.Commands.DeleteUser;
using Rebus.Domain.Entities;

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
    public async Task<ActionResult<UserGameAccessDto?>> GetByUserId([FromRoute] int id)
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
        var userGameAccessId = await mediator.Send(command);
        return Created();
       // return CreatedAtAction(nameof(GetByUserId), new {userId, gameId}, "accesses");
    }

    [HttpDelete("{userId}/accesses")]
    public async Task<IActionResult> DeleteUserGameAccessesByUserId([FromRoute] int userId)
    {
         await mediator.Send(new DeleteAllUserGameAccessesByUserIdCommand(userId));

        return NoContent();
    }


}