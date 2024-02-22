namespace Core.Application
{
    public interface IWrapperService
    {
        Task<string> ExecuteCommand(string target, IEnumerable<string> arguments);
    }
}
