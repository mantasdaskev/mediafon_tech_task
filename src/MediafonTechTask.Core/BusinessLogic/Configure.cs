using MediafonTechTask.Core.BusinessLogic.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MediafonTechTask.Core.BusinessLogic;

public static class Configure
{
    public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services)
    {
        services.AddTransient<ISubmissionsService, SubmissionsService>();

        return services;
    }
}
