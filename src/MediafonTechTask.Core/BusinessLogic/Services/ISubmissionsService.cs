// Ignore Spelling: Mediafon

using MediafonTechTask.Core.Enums;
using MediafonTechTask.Core.Models;

namespace MediafonTechTask.Core.BusinessLogic.Services;

public interface ISubmissionsService
{
    //TODO: rethink. Should take only 1 or 2 args
    Task<Submission> AddNewApplication(string userId, SubmissionType type, string message);

    IList<Submission> GetUserFormApplications(string userId);
}