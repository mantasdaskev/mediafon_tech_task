using MediafonTechTask.Core.BusinessLogic.Interfaces;
using MediafonTechTask.Core.Models;

namespace MediafonTechTask.Core.Data.Repositories;

internal class SubmissionsRepository : ISubmissionsRepository
{
    private readonly SubmissionsDbContext _context;

    public SubmissionsRepository(SubmissionsDbContext context)
    {
        _context = context;
    }

    public async Task<Submission> Add(Submission submission)
    {
        submission.CreatedAt = DateTime.UtcNow;
        _context.Submissions.Add(submission);
        await _context.SaveChangesAsync();
        return submission;
    }

    //TODO: maybe something that would not try to get all-all?..
    public IList<Submission> GetAllById(string userId)
    {
        return [.. _context.Submissions.Where(s => s.UserId == userId)];
    }
}