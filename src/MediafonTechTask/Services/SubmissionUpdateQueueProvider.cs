using MediafonTechTask.Core.Models;

namespace MediafonTechTask.Services;

//TODO: to be honest, i would use MediatR or something similar. I am not sure if hosted service would be good..
public static class SubmissionUpdateQueueProvider
{
    public static Queue<Submission> SubmissionsToUpdate { get; } = [];
}
