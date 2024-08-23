using Microsoft.AspNetCore.Mvc;
using MediafonTechTask.Core.BusinessLogic.Requests;
using MediafonTechTask.Core.BusinessLogic.Responses;
using MediafonTechTask.Core.BusinessLogic.Services;

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
    public ActionResult<GetSubmissionsResponse> GetApplications(string userId)
    {
        IList<Core.Models.Submission> submisssions = _submissionsService.GetUserFormApplications(userId);
        return Ok(GetSubmissionsResponse.Map(submisssions));
    }

    // POST api/submissions/new
    [HttpPost("new")]
    public async Task<ActionResult<NewSubmissionResponse>> PostNewApplication(NewSubmissionRequest request)
    {
        return Ok(await _submissionsService.AddNewApplication(request.UserId,
            request.Type, request.Message));
    }
}