namespace MediafonTechTask.BusinessLogic.Responses;

public class LoginResponse(string userName)
{
    public string Test => $"This is a login test. User {userName}";
}
