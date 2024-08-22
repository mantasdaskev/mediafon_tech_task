
using MediafonTechTask.BusinessLogic.Enums;
using MediafonTechTask.BusinessLogic.Models;
using MediafonTechTask.BusinessLogic.Requests;
using MediafonTechTask.BusinessLogic.Responses;
using Microsoft.AspNetCore.Mvc;

namespace MediafonTechTask.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ApplicationsController : ControllerBase
{
    public ApplicationsController()
    {
        
    }

    [HttpGet("{userId}")]
    public ActionResult<GetApplicationsResponse> GetApplications(string userId)
    {

        IList<FormApplicationDetails> applications =
        [
            new ("1", "2024-01-01", ApplicationType.Complaint, ApplicationState.Submitted),
            new ("2", "2024-01-02", ApplicationType.Request, ApplicationState.Submitted),
            new ("3", "2024-01-03", ApplicationType.Suggestion, ApplicationState.Confirmed),
        ];

        GetApplicationsResponse response = new(userId, applications);
        return Ok(response);
    }

    [HttpPost("new")]
    public IActionResult PostNewApplication(NewApplicationRequest request)
    {
        return Ok();
    }
}
