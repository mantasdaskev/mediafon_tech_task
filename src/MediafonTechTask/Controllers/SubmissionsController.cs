
using MediafonTechTask.BusinessLogic.Models;
using MediafonTechTask.BusinessLogic.Requests;
using MediafonTechTask.BusinessLogic.Responses;
using MediafonTechTask.BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace MediafonTechTask.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubmissionsController : ControllerBase
{
    private readonly ISubmissionsService _submissionsService;

    public SubmissionsController(ISubmissionsService submissionsService)
    {
        _submissionsService = submissionsService;
    }

    // GET api/submissions/{userId}
    [HttpGet("{userId}")]
    public async Task<ActionResult<GetSubmissionsResponse>> GetApplications(string userId)
    {
        IList<SubmissionDetails> applications = await _submissionsService.GetUserFormApplications(userId);
        GetSubmissionsResponse response = new(userId, applications);
        return Ok(response);
    }

    // POST api/submissions/new
    [HttpPost("new")]
    public async Task<ActionResult<NewSubmissionResponse>> PostNewApplication(NewSubmissionRequest request)
    {
        return Ok(await _submissionsService.AddNewApplication(request.UserId, 
            request.Type, request.Message));
    }
}
