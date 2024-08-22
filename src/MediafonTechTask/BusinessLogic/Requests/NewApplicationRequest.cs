using MediafonTechTask.BusinessLogic.Enums;

namespace MediafonTechTask.BusinessLogic.Requests;

public record NewApplicationRequest(ApplicationType Type, string Message);
