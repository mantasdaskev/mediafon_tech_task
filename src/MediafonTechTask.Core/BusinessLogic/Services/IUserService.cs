using MediafonTechTask.Core.Models;

namespace MediafonTechTask.Core.BusinessLogic.Services;

public interface IUserService
{
    Task<User> EnsureUser(string userName);
}
