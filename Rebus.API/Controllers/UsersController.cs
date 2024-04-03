using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rebus.Application.Users;
using Rebus.Application.Users.Commands.CreateUser;
using Rebus.Application.Users.Dtos;
using Rebus.Application.Users.Queries.GetAllUsers;
using Rebus.Application.Users.Queries.GetUserById;

namespace Rebus.API.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await mediator.Send(new GetAllUsersQuery());
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var user = await mediator.Send(new GetUserByIdQuery(id));

        if (user is null)
            return NotFound();
       
        return Ok(user);
    }
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserCommand command)
    {
        int id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new {id }, null);
    }


}
