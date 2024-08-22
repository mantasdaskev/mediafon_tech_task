using MediafonTechTask.Core.BusinessLogic.Enums;

namespace MediafonTechTask.Core.BusinessLogic.Models;

public record Submission(SubmissionType Type, string Message);