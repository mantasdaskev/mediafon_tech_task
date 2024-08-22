// Ignore Spelling: Mediafon

using MediafonTechTask.BusinessLogic.Enums;
using MediafonTechTask.BusinessLogic.Models;

namespace MediafonTechTask.BusinessLogic.Services;

internal sealed class SubmissionsService : ISubmissionsService
{
    public Task<IList<SubmissionDetails>> GetUserFormApplications(string userId)
    {
        IList<SubmissionDetails> applications =
        [
            new ("1", "2024-01-01", SubmissionType.Complaint, SubmissionState.Submitted),
            new ("2", "2024-01-02", SubmissionType.Request, SubmissionState.Submitted),
            new ("3", "2024-01-03", SubmissionType.Suggestion, SubmissionState.Confirmed),
        ];
        return Task.FromResult(applications);
    }

    public Task<Submission> AddNewApplication(string userId, SubmissionType type, string message)
    {
        return Task.FromResult(new Submission(type, message));
    }
}
