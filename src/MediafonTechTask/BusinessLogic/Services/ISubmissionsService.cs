// Ignore Spelling: Mediafon

using MediafonTechTask.BusinessLogic.Enums;
using MediafonTechTask.BusinessLogic.Models;

namespace MediafonTechTask.BusinessLogic.Services;

public interface ISubmissionsService
{
    //TODO: rethink. Should take only 1 or 2 args
    Task<Submission> AddNewApplication(string userId, SubmissionType type, string message);

    Task<IList<SubmissionDetails>> GetUserFormApplications(string userId);
}
