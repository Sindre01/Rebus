using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rebus.Application.Users;
using Rebus.Application.Users.Commands.CreateUser;
using Rebus.Application.Users.Commands.DeleteUser;
using Rebus.Application.Users.Commands.UpdateUser;
using Rebus.Application.Users.Dtos;
using Rebus.Application.Users.Queries.GetAllUsers;
using Rebus.Application.Users.Queries.GetUserById;

namespace Rebus.API.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAll()
    {
        var users = await mediator.Send(new GetAllUsersQuery());
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserDto?>> GetById([FromRoute] int id)
    {
        var user = await mediator.Send(new GetUserByIdQuery(id));

        if (user is null)
            return NotFound();
       
        return Ok(user);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteUser([FromRoute] int id)
    {
        var isDeleted = await mediator.Send(new DeleteUserCommand(id));

        if (isDeleted)
            return NoContent();

        return NotFound() ;
    }

    [HttpPatch("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateUserLocation([FromRoute] int id, UpdateUserLocationCommand command)
    {
        command.Id = id;
        var isUpdated = await mediator.Send(command);

        if (isUpdated)
            return NoContent();

        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserCommand command)
    {
        int id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new {id }, null);
    }


}
