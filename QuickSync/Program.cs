// First run config create
// Add colors to steps
// add run obsidian at the end
// add save to git at close console

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services
        .AddTransient<IWrapperService, WrapperService>()
        .AddDbContext<GitDbContext>(options => options.UseSqlite($"Data Source=connectionsDb.db"))
        .AddScoped<AppRun>()
        .AddScoped<Menu>())
    .Build();

var menu = ActivatorUtilities.CreateInstance<Menu>(host.Services);
var db = ActivatorUtilities.CreateInstance<GitDbContext>(host.Services);

if (db.EditorModes.FirstOrDefault().IsEditorModeActive)
{
    await menu.UseMenu();
}

var initializer = ActivatorUtilities.CreateInstance<AppRun>(host.Services);
await initializer.Run();
