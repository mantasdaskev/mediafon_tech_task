using MediafonTechTask.Core.BusinessLogic.Models;

namespace MediafonTechTask.Core.BusinessLogic.Responses;

//TODO: delete user Id. Used for testing
public record GetSubmissionsResponse(string UserId, IList<SubmissionDetails> Applications);
