using Microsoft.EntityFrameworkCore;
using MediafonTechTask.Core.Models;

namespace MediafonTechTask.Core.Data;

public class SubmissionsDbContext : DbContext
{
    public SubmissionsDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Submission> Submissions { get; set; }

    //TODO: could be renamed EnsureEntity and could create new maybe? idk...
    public async Task<T> GetEntity<T>() where T : class
    {
        DbSet<T>? dbSet = Set<T>() ?? throw new Exception($"No such set {typeof(T).Name}"); //TODO: make custom
        T? entity = await dbSet.FirstOrDefaultAsync(); //TODO: is the FOD async necessary?
        return entity ?? throw new Exception($"No such entity {typeof(T).Name}");
    }
}