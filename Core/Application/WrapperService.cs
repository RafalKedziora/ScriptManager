using CliWrap;
using CliWrap.Buffered;

namespace Core.Application
{
    public class WrapperService : IWrapperService
    {
        public async Task<string> ExecuteCommand(string target, IEnumerable<string> arguments)
        {
            var cmd = await Cli.Wrap(target)
                .WithArguments(arguments)
                .ExecuteBufferedAsync();
            
            return cmd.StandardOutput;
        }
    }
}
