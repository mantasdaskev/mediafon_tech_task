
using MediafonTechTask.Core.BusinessLogic.Interfaces;
using MediafonTechTask.Core.BusinessLogic.Services;
using MediafonTechTask.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace MediafonTechTask.Services;

public class SubmissionStateUpdater : BackgroundService//IHostedService
{
    private readonly ISubmissionsService _submissionsService;
    private readonly IHubContext<SubmissionsStateHub, ISubmissionsStateEvents> _hubContext;
    private readonly ILogger<SubmissionStateUpdater> _logger;

    private PeriodicTimer _periodicTimer = new(TimeSpan.FromSeconds(60));

    public SubmissionStateUpdater(IServiceScopeFactory factory,
        IHubContext<SubmissionsStateHub, ISubmissionsStateEvents> hubContext,
        ILogger<SubmissionStateUpdater> logger)
    {
        _submissionsService = factory.CreateScope().ServiceProvider.GetRequiredService<ISubmissionsService>();
        _hubContext = hubContext;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            if(SubmissionUpdateQueueProvider.SubmissionsToUpdate.Count > 0)
            {
                await HandleUpdate();
            }
            await Task.Delay(100, cancellationToken);
        }
    }

    private async Task HandleUpdate()
    {
        //Not exactly after minute, but it is something that came up at the last minute
        //TODO: fix
        while (await _periodicTimer.WaitForNextTickAsync())
        {
            if (SubmissionUpdateQueueProvider.SubmissionsToUpdate.Count > 0)
            {
                Core.Models.Submission sub = SubmissionUpdateQueueProvider.SubmissionsToUpdate.Dequeue();
                await UpdateSubmission(sub);
            }
            else
            {
                return;
            }
        }
    }

    private async Task UpdateSubmission(Core.Models.Submission sub)
    {
        try
        {
            await _submissionsService.ConfirmSubmission(sub);

            // As hub has no usable user context, I just send update to all connections.
            // If the token would be provided, we could get user id from claims..
            //TODO: fix
            await _hubContext.Clients.All
                .ReceiveSubmissionUpdate(Core.BusinessLogic.Responses.Submission.Map(sub));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to notify about submission update.");
        }
    }
}
