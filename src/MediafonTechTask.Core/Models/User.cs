using MediafonTechTask.Core.BusinessLogic.Interfaces;

namespace MediafonTechTask.Core.Models;

public class User : IEntity
{
    public string? Id { get; set; }

    public string? UserName { get; set; }

    public string? PasswordHash { get; set; }

    public IEnumerable<Submission> Submissions { get; set; } = [];
}
