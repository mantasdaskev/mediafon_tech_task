using MediafonTechTask.Core.Enums;

namespace MediafonTechTask.Core.BusinessLogic.Responses;

public record GetSubmissionsResponse(IList<Submission> Submissions)
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

public record Submission(string Id, string Date, SubmissionType Type, SubmissionState State)
{
    public static Submission Map(Models.Submission submission)
    {
        return new(submission.Id ?? throw new Exception("Submission must have an id"), //TODO: custom exc or validations?
            submission.CreatedAt.Date.ToString("yyyy-MM-dd"), 
            submission.Type, 
            submission.State);
    }
}