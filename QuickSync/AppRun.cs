using Serilog;
namespace ObsidianCustomRuntime
{
    public class AppRun
    {
        private readonly IHost host;
        private readonly GitDbContext context;

        public AppRun(IHost host, GitDbContext context)
        {
            this.host = host;
            this.context = context;
        }

        public async Task Run()
        {
            using var log = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();

            var wrapperService = ActivatorUtilities.CreateInstance<WrapperService>(host.Services);

            var data = this.context.GitRepoInfos.FirstOrDefault();
            var clonedRepositoryLoc = DirectoryHelper.PathUpdater(data.PathToFile, data.UrlToRepository);
            if (!DirectoryHelper.IsRepositoryCloned(clonedRepositoryLoc))
            {
                log.Information(
                await wrapperService.CloneRepository(data.UrlToRepository, data.PathToFile)
                );
            }
            else
            {
                log.Information(
                await wrapperService.PullRepository(data.UrlToRepository, clonedRepositoryLoc)
                );
            }

            if (data.PathToRunProgram != null && File.Exists(data.PathToRunProgram))
            {
                log.Information("Path to the program exists and is valid, running...");
                
                await wrapperService.RunProgram(data.PathToRunProgram);
                
                log.Information("Program was closed by the user");
            }

            var response = await wrapperService.CheckStatusAsync(clonedRepositoryLoc);

            if (!response.Contains("tree clean"))
            {
                log.Information("There are changes in the file. Start sync operation");
                
                log.Information(
                await wrapperService.AddAllChanges(clonedRepositoryLoc)
                );

                log.Information(
                await wrapperService.CommitChanges(clonedRepositoryLoc)
                );
            }
        }
    }
}
