// Ignore Spelling: Mediafon

using MediafonTechTask.Core.BusinessLogic.Enums;
using MediafonTechTask.Core.BusinessLogic.Models;

namespace MediafonTechTask.Core.BusinessLogic.Services;

public interface ISubmissionsService
{
    //TODO: rethink. Should take only 1 or 2 args
    Task<Submission> AddNewApplication(string userId, SubmissionType type, string message);

    Task<IList<SubmissionDetails>> GetUserFormApplications(string userId);
}
