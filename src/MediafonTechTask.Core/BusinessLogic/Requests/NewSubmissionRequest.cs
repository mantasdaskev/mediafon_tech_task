using MediafonTechTask.Core.Enums;

namespace MediafonTechTask.Core.BusinessLogic.Requests;

public record NewSubmissionRequest(string UserId, SubmissionType Type, string Message);