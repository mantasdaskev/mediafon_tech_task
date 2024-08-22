using MediafonTechTask.BusinessLogic.Enums;

namespace MediafonTechTask.BusinessLogic.Models;

public record FormApplicationDetails(string Id, string Date, ApplicationType Type, ApplicationState State);
