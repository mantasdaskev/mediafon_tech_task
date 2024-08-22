using MediafonTechTask.BusinessLogic.Requests;
using MediafonTechTask.BusinessLogic.Responses;
using Microsoft.AspNetCore.Mvc;

namespace MediafonTechTask.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    // POST api/login
    [HttpPost]
    public ActionResult<LoginResponse> Login(LoginRequest request)
    {
        return Ok(new LoginResponse(request.UserName));
    }
}
