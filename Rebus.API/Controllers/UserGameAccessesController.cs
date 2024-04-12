using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rebus.Application.UserGameAccesses;
using Rebus.Application.UserGameAccesses.Commands.CreateUserGameAccess;
using Rebus.Application.UserGameAccesses.Dtos;

namespace Rebus.API.Controllers;

[ApiController]
[Route("api/users")]
public class UserGameAccessesController(
    IUserGameAccessesService userGameAccessesService, //Remove later
    IMediator mediator) : ControllerBase
{
    [HttpGet]
    [Route("games/accesses")]
    public async Task<ActionResult<IEnumerable<UserGameAccessDto>>> GetAll()
    {
        var userGameAccesses = await userGameAccessesService.GetAllUserGameAccesses();
        return Ok(userGameAccesses);
    }

    [HttpGet("{id}/games/accesses")]
    public async Task<ActionResult<UserGameAccessDto>> GetById([FromRoute] int id)
    {
        var gameUserAccesses = await userGameAccessesService.GetById(id);
        if (gameUserAccesses is null)
            return NotFound();

        return Ok(gameUserAccesses);
    }

    [HttpPost("{userId}/games/{gameId}/accesses")]
    public async Task<IActionResult> CreateUserGameAccess([FromRoute] int userId, [FromRoute] int gameId, CreateUserGameAccessCommand command)
    {
        command.UserId = userId;
        command.GameId = gameId;
        await mediator.Send(command);
        return Created();
    }


}