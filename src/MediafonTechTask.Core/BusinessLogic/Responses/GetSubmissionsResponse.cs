using MediafonTechTask.Core.Enums;

namespace MediafonTechTask.Core.BusinessLogic.Responses;

//TODO: delete user Id. Used for testing
public record GetSubmissionsResponse(string UserId, IList<Submission> Submissions)
{
    public static IList<Submission> Map(IList<Models.Submission> submissions)
    {
        IList<Submission> mapped = [];
        foreach (var submission in submissions)
        {
            mapped.Add(Submission.Map(submission));
        }
        return mapped;
    }
}

public record Submission(string Id, SubmissionType Type, SubmissionState State)
{
    public static Submission Map(Models.Submission submission)
    {
        return new(submission.Id ?? throw new Exception("Submission must have an id"), //TODO: custom exc or validations?
            submission.Type, submission.State);
    }
}