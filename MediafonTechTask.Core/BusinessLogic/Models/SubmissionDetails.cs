using MediafonTechTask.Core.BusinessLogic.Enums;

namespace MediafonTechTask.Core.BusinessLogic.Models;

public record SubmissionDetails(string Id, string Date, SubmissionType Type, SubmissionState State);
