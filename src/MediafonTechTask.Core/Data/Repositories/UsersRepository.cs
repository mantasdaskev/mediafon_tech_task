using MediafonTechTask.Core.BusinessLogic.Interfaces;
using MediafonTechTask.Core.Models;

namespace MediafonTechTask.Core.Data.Repositories;

internal class UsersRepository : IUsersRepository
{
    private readonly SubmissionsDbContext _context;

    //TODO: add arg null check everywhere.
    public UsersRepository(SubmissionsDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetByUserName(string userName)
    {
        User? user = _context.Users.FirstOrDefault(u => u.UserName == userName);
        if (user is not null)
        {
            return user;
        }

        return await _context.EnsureEntity(new User()
        { 
            Id = Guid.NewGuid().ToString(), 
            UserName = userName
        });
    }
}