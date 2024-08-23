using MediafonTechTask.Core.Models;

namespace MediafonTechTask.Core.BusinessLogic.Interfaces;

public interface ISubmissionsRepository
{
    Task<Submission> Add(Submission submission);

    IList<Submission> GetAllById(string userId);
}