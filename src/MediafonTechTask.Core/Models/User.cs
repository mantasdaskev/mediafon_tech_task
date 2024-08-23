namespace MediafonTechTask.Core.Models;

public class User
{
    public string? Id { get; set; }

    public string? UserName { get; set; }

    public string? PasswordHash { get; set; }

    public IEnumerable<Submission> Submissions { get; set; } = Enumerable.Empty<Submission>();
}
