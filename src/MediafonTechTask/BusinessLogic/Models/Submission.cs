using MediafonTechTask.BusinessLogic.Enums;

namespace MediafonTechTask.BusinessLogic.Models;

public record Submission(SubmissionType Type, string Message);