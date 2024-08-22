using MediafonTechTask.BusinessLogic.Enums;

namespace MediafonTechTask.BusinessLogic.Requests;

public record NewSubmissionRequest(string UserId, SubmissionType Type, string Message);
