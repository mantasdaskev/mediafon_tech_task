using Microsoft.AspNetCore.Mvc;
using MediafonTechTask.Core.BusinessLogic.Requests;
using MediafonTechTask.Core.BusinessLogic.Responses;
using MediafonTechTask.Core.BusinessLogic.Services;
using MediafonTechTask.Services;

namespace MediafonTechTask.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SubmissionsController : ControllerBase
{
    private readonly ISubmissionsService _submissionsService;
    private readonly ILogger<SubmissionsController> _logger;

    public SubmissionsController(ISubmissionsService submissionsService, ILogger<SubmissionsController> logger)
    {
        _submissionsService = submissionsService;
        _logger = logger;
    }

    // GET api/submissions/{userId}
    [HttpGet("{userId}")]
    public ActionResult<GetSubmissionsResponse> GetSubmissions(string userId)
    {
        try
        {
            IList<Core.Models.Submission> submisssions = _submissionsService.GetUserFormApplications(userId);
            return Ok(GetSubmissionsResponse.Map(submisssions));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to provide submissions.");
            //TODO: should track more exceptions....
            return BadRequest();
        }
    }

    // POST api/submissions/new
    [HttpPost("new")]
    public async Task<IActionResult> PostNewSubmission(NewSubmissionRequest request)
    {
        try
        {
            Core.Models.Submission submission = await _submissionsService.AddNewApplication(request.UserId,
                request.Type, request.Message);
            SubmissionUpdateQueueProvider.SubmissionsToUpdate.Enqueue(submission);
            return Ok(submission);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to create new submission.");
            return BadRequest();
        }
    }
}