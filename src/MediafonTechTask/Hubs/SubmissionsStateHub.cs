using MediafonTechTask.Core.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace MediafonTechTask.Hubs;

public class SubmissionsStateHub : Hub<ISubmissionsStateEvents>
{
    private readonly ILogger<SubmissionsStateHub> _logger;

    public SubmissionsStateHub(ILogger<SubmissionsStateHub> logger)
    {
        _logger = logger;
    }

    public override Task OnConnectedAsync()
    {
        _logger.LogInformation("Client connected {UserId}", Context.UserIdentifier);
        return base.OnConnectedAsync();
    }

    public override Task OnDisconnectedAsync(Exception? ex)
    {
        _logger.LogInformation("Client disconnected {UserId}", Context.UserIdentifier);
        if(ex is not null)
        {
            _logger.LogError(ex, "Connection ended with an error. ");
        }

        return base.OnDisconnectedAsync(ex);
    }
}
