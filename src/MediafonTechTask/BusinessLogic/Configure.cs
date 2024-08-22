using MediafonTechTask.BusinessLogic.Services;

namespace MediafonTechTask.BusinessLogic;

public static class Configure
{
    public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services)
    {
        services.AddTransient<IApplicationsService, ApplicationsService>();

        return services;
    }
}
