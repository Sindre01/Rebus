using Microsoft.AspNetCore.Mvc;
using Rebus.Application.GameUserAccesses;

namespace Rebus.API.Controllers;

[ApiController]
[Route("api/users")]
public class GameUserAccessesController(IGameUserAccessesService GameUserAccessesService) : ControllerBase
{
    [HttpGet]
    [Route("games/accesses")]
    public async Task<IActionResult> GetAll()
    {
        var GameUserAccesses = await GameUserAccessesService.GetAllGameUserAccesses();
        return Ok(GameUserAccesses);
    }

    [HttpGet("{id}/games/accesses")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var gameUserAccesses = await GameUserAccessesService.GetById(id);
        if (gameUserAccesses is null)
            return NotFound();

        return Ok(gameUserAccesses);
    }


}