using CliWrap;
using CliWrap.Buffered;
using System.IO;

namespace Application
{
    public class WrapperService : IWrapperService
    {
        public async Task<string> CheckStatusAsync(string path)
        {
            var cmd = await Cli.Wrap("git")
               .WithArguments("status")
               .WithWorkingDirectory(path)
               .ExecuteBufferedAsync();

            return cmd.StandardOutput;
        }

        public async Task<string> CloneRepository(string url,string path)
        {   
            var cmd = await Cli.Wrap("git")
                .WithWorkingDirectory(path)
                .WithArguments(args => args
                .Add("clone")
                .Add(url + ".git")
                ).ExecuteBufferedAsync();
            return cmd.StandardOutput;
        }

        public async Task<string> AddAllChanges(string path)
        {
            var cmd = await Cli.Wrap("git")
                .WithArguments("add .")
                .WithWorkingDirectory(path)
                .ExecuteBufferedAsync();

            return cmd.StandardOutput;
        }

        public async Task<string> CommitChanges(string path, string customMessage = "update repo")
        {
            var cmd = await Cli.Wrap("git")
                .WithArguments($"commit -m {customMessage}")
                .WithWorkingDirectory(path)
                .ExecuteBufferedAsync();

            return cmd.StandardOutput;
        }

        public async Task<string> PullRepository(string url, string path)
        {
            var cmd = await Cli.Wrap("git")
                .WithArguments($"pull {url}")
                .WithWorkingDirectory(path)
                .ExecuteBufferedAsync();

            return cmd.StandardOutput;
        }

        public async Task RunProgram(string pathToProgram)
        {
            if (OperatingSystem.IsWindows())
            {
                var cmd = await Cli.Wrap(pathToProgram).ExecuteBufferedAsync();
            }
            else
            {
                Cli.Wrap($"./{pathToProgram}");
            }
        }
    }
}
