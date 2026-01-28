using Microsoft.AspNetCore.Mvc;
using TripMate.Application.Users.Interfaces;

namespace TripMate.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetProfileAsync(id);
        if (user == null)
            return NotFound();

        return Ok(user);
    }
}
