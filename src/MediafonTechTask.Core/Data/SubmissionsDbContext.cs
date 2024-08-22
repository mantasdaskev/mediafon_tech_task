using Microsoft.EntityFrameworkCore;

namespace MediafonTechTask.Core.Data;

internal class SubmissionsDbContext : DbContext
{
    public SubmissionsDbContext(DbContextOptions options) : base(options)
    {
        
    }
}
