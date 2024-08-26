using Microsoft.EntityFrameworkCore;
using MediafonTechTask.Core.Models;
using MediafonTechTask.Core.BusinessLogic.Interfaces;

namespace MediafonTechTask.Core.Data;

public class SubmissionsDbContext : DbContext
{
    public SubmissionsDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }

    public DbSet<Submission> Submissions { get; set; }

    //TODO: this one is a bit off. Remake
    public async Task<T> GetEntity<T>() where T : class
    {
        DbSet<T>? dbSet = Set<T>() ?? throw new Exception($"No such set {typeof(T).Name}"); //TODO: make custom
        T? entity = await dbSet.FirstOrDefaultAsync();
        return entity ?? throw new Exception($"No such entity {typeof(T).Name}");
    }

    public async Task<T> EnsureEntity<T>(T entityToCreate) where T : class, IEntity
    {
        DbSet<T>? dbSet = Set<T>() ?? throw new Exception($"No such set {typeof(T).Name}"); //TODO: make custom

        T? entity = await dbSet.FirstOrDefaultAsync(e => e.Id == entityToCreate.Id);
        if (entity is not null)
        {
            return entity;
        }

        await Set<T>().AddAsync(entityToCreate);
        await SaveChangesAsync();

        return entityToCreate;
    }
}