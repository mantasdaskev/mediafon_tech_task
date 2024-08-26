using MediafonTechTask.Core.Models;

namespace MediafonTechTask.Core.BusinessLogic.Interfaces;

public interface IUsersRepository
{
    Task<User> GetByUserName(string userName);
}