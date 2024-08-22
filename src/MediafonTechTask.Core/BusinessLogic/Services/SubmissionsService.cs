// Ignore Spelling: Mediafon

using MediafonTechTask.Core.BusinessLogic.Interfaces;
using MediafonTechTask.Core.Enums;
using MediafonTechTask.Core.Models;

namespace MediafonTechTask.Core.BusinessLogic.Services;

internal sealed class SubmissionsService : ISubmissionsService
{
    private readonly ISubmissionsRepository _repository;

    public SubmissionsService(ISubmissionsRepository repository)
    {
        _repository = repository;
    }

    public IList<Submission> GetUserFormApplications(string userId)
    {
        return _repository.GetAllById(userId);
    }

    public Task<Submission> AddNewApplication(string userId, SubmissionType type, string message)
    {
        return _repository.Add(new Submission
        {
            Id = Guid.NewGuid().ToString(),
            UserId = userId,
            Type = type,
            Message = message,
            State = SubmissionState.Submitted,
        });
    }
}