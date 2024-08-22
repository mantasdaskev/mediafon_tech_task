using MediafonTechTask.BusinessLogic.Models;

namespace MediafonTechTask.BusinessLogic.Responses;

//TODO: delete user Id. Used for testing
public record GetSubmissionsResponse(string UserId, IList<SubmissionDetails> Applications);
