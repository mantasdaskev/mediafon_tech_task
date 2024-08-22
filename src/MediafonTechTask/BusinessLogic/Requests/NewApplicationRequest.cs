using MediafonTechTask.BusinessLogic.Enums;

namespace MediafonTechTask.BusinessLogic.Requests;

public record NewApplicationRequest(string UserId, ApplicationType Type, string Message);
