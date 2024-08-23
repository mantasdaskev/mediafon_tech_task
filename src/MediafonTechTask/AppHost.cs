// Ignore Spelling: App

using MediafonTechTask.Core.BusinessLogic;
using MediafonTechTask.Core.Data;

namespace MediafonTechTask;

public sealed class AppHost : AppHostBase
{
    public void RunMigrations()
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder();
        builder.Services.AddDataLayer(builder.Configuration);

        WebApplication app = builder.Build();
        app.Services.RunMigrations();
    }

    protected override void PreWebApplicationBuildConfig(WebApplicationBuilder builder, IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers(); // TODO: move to base later

        services.AddBusinessLogicLayer();
        services.AddDataLayer(configuration);
    }

    protected override void PostWebApplicationBuildConfig(WebApplication app)
    {
        app.MapGet("/", () => "Hello World!");

        app.MapControllers();

        //TODO: add swagger
        //TODO: add health check or MapGet with text running or smth
    }
}