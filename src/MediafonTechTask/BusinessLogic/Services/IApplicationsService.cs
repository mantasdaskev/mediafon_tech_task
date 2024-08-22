// Ignore Spelling: Mediafon

using MediafonTechTask.BusinessLogic.Enums;
using MediafonTechTask.BusinessLogic.Models;

namespace MediafonTechTask.BusinessLogic.Services;

public interface IApplicationsService
{
    //TODO: rethink. Should take only 1 or 2 args
    Task<FormApplication> AddNewApplication(string userId, ApplicationType type, string message);

    Task<IList<FormApplicationDetails>> GetUserFormApplications(string userId);
}
