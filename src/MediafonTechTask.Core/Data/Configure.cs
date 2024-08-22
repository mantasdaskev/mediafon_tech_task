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
        string? tst = configuration.GetConnectionString("PgDbConnectionStringg");
            if (string.IsNullOrEmpty(tst))
            {
                Console.WriteLine("Dick");
            }
            else
            {
                Console.WriteLine($"Dick ==> {tst}");
            }
        services.AddDbContext<SubmissionsDbContext>(options =>
        {
            
            options.UseNpgsql();
        });

        services.AddTransient<IUsersRepository, UsersRepository>();
        services.AddTransient<ISubmissionsRepository, SubmissionsRepository>();
        return services;
    }
}
