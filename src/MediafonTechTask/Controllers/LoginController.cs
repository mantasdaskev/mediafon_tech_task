using MediafonTechTask.Core.BusinessLogic.Requests;
using MediafonTechTask.Core.BusinessLogic.Responses;
using MediafonTechTask.Core.BusinessLogic.Services;
using MediafonTechTask.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediafonTechTask.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IUserService _userService;

    public LoginController(IUserService userService)
    {
        _userService = userService;
    }

    // POST api/login
    [HttpPost]
    public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
    {
        User user = await _userService.EnsureUser(request.UserName);
        if (string.IsNullOrEmpty(user.Id))
        {
            throw new Exception("User id was not set."); //TODO:
        }

        return Ok(new LoginResponse(user.Id));
    }
}
