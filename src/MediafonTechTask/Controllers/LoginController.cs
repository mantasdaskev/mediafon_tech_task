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
    private readonly ILogger<LoginController> _logger;

    public LoginController(IUserService userService, ILogger<LoginController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    // POST api/login
    [HttpPost]
    public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
    {
        try
        {
            User user = await _userService.EnsureUser(request.UserName);
            if (string.IsNullOrEmpty(user.Id))
            {
                throw new Exception("User id was not set."); //TODO:
            }

            return Ok(new LoginResponse(user.Id));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get user {UserName}.", request.UserName);
            return BadRequest();
        }
    }
}
