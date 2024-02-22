using Core;
using Core.Application;
using Core.Domain.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Persistence;

using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((cfg, services) =>
    {
        var appConfig = cfg.Configuration.GetSection("ConnectionStrings:Sqlite").Get<AppConfig>();

        services
            .AddTransient<IWrapperService, WrapperService>()
            .AddDbContext<GitDbContext>(options =>
                options.UseSqlite(appConfig!.ConnectionStrings.Sqlite))

            .AddTransient<AppRun>();
    })
    .Build();

var initializer = host.Services.GetRequiredService<AppRun>();
await initializer.RunAsync();
