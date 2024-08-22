using Microsoft.Extensions.Logging;

namespace MediafonTechTask;

public abstract class AppHostBase
{
    public void BuildAndRun(string[] args)
    {
        try
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            PreWebApplicationBuildConfig(builder, builder.Services);

            WebApplication app = builder.Build();

            PostWebApplicationBuildConfig(app);

            app.Run();
        }
        catch (Exception)
        {
            // TODO: log, check stop on separate catch.
            throw;
        }
    }

    protected virtual void PreWebApplicationBuildConfig(WebApplicationBuilder builder, IServiceCollection services)
    {
    }

    protected virtual void PostWebApplicationBuildConfig(WebApplication app)
    {
    }
}
