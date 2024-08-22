// Ignore Spelling: Mediafon

using MediafonTechTask.BusinessLogic.Enums;
using MediafonTechTask.BusinessLogic.Models;

namespace MediafonTechTask.BusinessLogic.Services;

internal sealed class ApplicationsService : IApplicationsService
{
    public Task<IList<FormApplicationDetails>> GetUserFormApplications(string userId)
    {
        IList<FormApplicationDetails> applications =
        [
            new ("1", "2024-01-01", ApplicationType.Complaint, ApplicationState.Submitted),
            new ("2", "2024-01-02", ApplicationType.Request, ApplicationState.Submitted),
            new ("3", "2024-01-03", ApplicationType.Suggestion, ApplicationState.Confirmed),
        ];
        return Task.FromResult(applications);
    }

    public Task<FormApplication> AddNewApplication(string userId, ApplicationType type, string message)
    {
        return Task.FromResult(new FormApplication(type, message));
    }
}
