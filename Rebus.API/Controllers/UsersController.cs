using Microsoft.AspNetCore.Mvc;
using Rebus.Application.Users;

namespace Rebus.API.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController(IUsersService usersService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await usersService.GetAllUsers(); 
        return Ok(users);
    }
}
