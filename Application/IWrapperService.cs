namespace Application
{
    public interface IWrapperService
    {
        Task<string> CheckStatusAsync(string path);


        Task<string> CloneRepository(string url, string path);

        Task<string> CommitChanges(string path, string customMessage = "update repo");

        Task<string> AddAllChanges(string path);

        Task RunProgram(string pathToProgram);
    }
}
