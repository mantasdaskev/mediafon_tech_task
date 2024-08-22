using MediafonTechTask.Core.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MediafonTechTask.Core.Data.Models;

public class Submission
{
    [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string? Id { get; set; }

    public SubmissionType Type { get; set; }

    public SubmissionState State { get; set; }

    public string? Message { get; set; }

    public string? UserId { get; set; }

    [Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)] // not identity per say, but must not change once set
    public DateTime CreatedAt { get; set; }
}
