using MediafonTechTask.Core.BusinessLogic.Interfaces;
using MediafonTechTask.Core.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MediafonTechTask.Core.Data;

public static class Configure
{
    public static IServiceCollection AddDataLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SubmissionsDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("PgDbConnectionString"));
        });

        services.AddTransient<IUsersRepository, UsersRepository>();
        services.AddTransient<ISubmissionsRepository, SubmissionsRepository>();
        return services;
    }
}
