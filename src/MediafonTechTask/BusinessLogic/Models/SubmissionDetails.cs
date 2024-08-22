using MediafonTechTask.BusinessLogic.Enums;

namespace MediafonTechTask.BusinessLogic.Models;

public record SubmissionDetails(string Id, string Date, SubmissionType Type, SubmissionState State);
