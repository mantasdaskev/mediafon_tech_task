using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MediafonTechTask.Core.BusinessLogic.Interfaces;
using MediafonTechTask.Core.Data.Repositories;

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

    //TODO: bs name. Change
    public static void RunMigrations(this IServiceProvider services)
    {
        using var scope = services.CreateScope();

        SubmissionsDbContext dbContext = scope.ServiceProvider.GetRequiredService<SubmissionsDbContext>();
        dbContext.Database.Migrate();
    }

    // for migrations
    // dotnet ef migrations add InitialMigration --project MediafonTechTask.Core.csproj --startup-project ../MediafonTechTask/MediafonTechTask.csproj
}