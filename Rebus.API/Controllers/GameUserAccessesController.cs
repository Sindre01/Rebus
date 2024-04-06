using Microsoft.AspNetCore.Mvc;
using Rebus.Application.GameUserAccesses;
using Rebus.Application.GameUserAccesses.Dtos;
using Rebus.Application.Users.Dtos;

namespace Rebus.API.Controllers;

[ApiController]
[Route("api/users")]
public class GameUserAccessesController(IGameUserAccessesService GameUserAccessesService) : ControllerBase
{
    [HttpGet]
    [Route("games/accesses")]
    public async Task<ActionResult<IEnumerable<GameUserAccessDto>>> GetAll()
    {
        var GameUserAccesses = await GameUserAccessesService.GetAllGameUserAccesses();
        return Ok(GameUserAccesses);
    }

    [HttpGet("{id}/games/accesses")]
    public async Task<ActionResult<GameUserAccessDto>> GetById([FromRoute] int id)
    {
        var gameUserAccesses = await GameUserAccessesService.GetById(id);
        if (gameUserAccesses is null)
            return NotFound();

        return Ok(gameUserAccesses);
    }


}