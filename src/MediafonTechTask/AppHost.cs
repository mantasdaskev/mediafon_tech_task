// Ignore Spelling: App

using MediafonTechTask.Core.BusinessLogic;
using MediafonTechTask.Core.Data;
using MediafonTechTask.Hubs;
using MediafonTechTask.Services;

namespace MediafonTechTask;

public sealed class AppHost : AppHostBase
{
    private const string CorspolicyName = "AjsAppPolicy";

    public void RunMigrations()
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder();
        builder.Services.AddDataLayer(builder.Configuration);

        WebApplication app = builder.Build();
        app.Services.RunMigrations();
    }

    protected override void PreWebApplicationBuildConfig(WebApplicationBuilder builder, IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(opt =>
        {
            opt.AddPolicy(CorspolicyName, builder =>
            {
                builder.WithOrigins("http://localhost:4200") //TODO: move uri to settings
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                //TODO: add auth stuff 
            });
        });

        services.AddSignalR();

        services.AddControllers(); // TODO: move to base later

        services.AddBusinessLogicLayer();
        services.AddDataLayer(configuration);

        services.AddHostedService<SubmissionStateUpdater>();

    }

    protected override void PostWebApplicationBuildConfig(WebApplication app)
    {
        app.MapGet("/", () => "Hello World!");

        app.MapHub<SubmissionsStateHub>("submissions-state-hub");

        app.MapControllers();

        app.UseCors(CorspolicyName);

        //TODO: add swagger
        //TODO: add health check or MapGet with text running or smth
    }
}