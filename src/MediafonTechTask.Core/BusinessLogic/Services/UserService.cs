
using MediafonTechTask.Core.BusinessLogic.Interfaces;
using MediafonTechTask.Core.Models;

namespace MediafonTechTask.Core.BusinessLogic.Services;

internal class UserService : IUserService
{
    private readonly IUsersRepository _repository;

    public UserService(IUsersRepository repository)
    {
        _repository = repository;
    }

    public Task<User> EnsureUser(string userName)
    {
        return _repository.GetByUserName(userName);
    }
}
