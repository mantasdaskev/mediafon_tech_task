using MediafonTechTask.Core.BusinessLogic.Responses;

namespace MediafonTechTask.Core.BusinessLogic.Interfaces
{
    public interface ISubmissionsStateEvents
    {
        Task ReceiveSubmissionUpdate(Submission submission);
    }
}
