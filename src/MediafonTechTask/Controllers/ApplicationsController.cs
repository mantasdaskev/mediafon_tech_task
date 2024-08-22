
using MediafonTechTask.BusinessLogic.Models;
using MediafonTechTask.BusinessLogic.Requests;
using MediafonTechTask.BusinessLogic.Responses;
using MediafonTechTask.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace MediafonTechTask.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationsController : ControllerBase
{
    private readonly IApplicationsService _applicationsService;

    public ApplicationsController(IApplicationsService applicationsService)
    {
        _applicationsService = applicationsService;
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<GetApplicationsResponse>> GetApplications(string userId)
    {
        IList<FormApplicationDetails> applications = await _applicationsService.GetUserFormApplications(userId);
        GetApplicationsResponse response = new(userId, applications);
        return Ok(response);
    }

    [HttpPost("new")]
    public async Task<ActionResult<NewApplicationResponse>> PostNewApplication(NewApplicationRequest request)
    {
        return Ok(await _applicationsService.AddNewApplication(request.UserId, 
            request.Type, request.Message));
    }
}
