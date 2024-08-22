
namespace MediafonTechTask;

public sealed class AppHost : AppHostBase
{
    protected override void PostWebApplicationBuildConfig(WebApplication app)
    {
        app.MapGet("/", () => "Hello World!");
    }
}
