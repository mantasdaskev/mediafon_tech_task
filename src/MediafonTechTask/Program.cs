using MediafonTechTask;

AppHost appHost = new();
if (args.Contains("--run-migrations"))
{
    appHost.RunMigrations();
}
else
{
    appHost.BuildAndRun(args);
}