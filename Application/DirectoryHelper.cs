namespace Application
{
    public static class DirectoryHelper
    {
        public static Task DirectoryCreator(string fullPath)
        {
            if (!Directory.Exists(fullPath))
            {
                Console.WriteLine("This repository doesn't exist. Do you want to create? (Y/N)");
                var answer = Console.ReadKey().Key;
                if (answer == ConsoleKey.Y)
                {
                    Directory.CreateDirectory(fullPath);
                }
                else
                {
                    Environment.Exit(0);
                }
            }

            return Task.CompletedTask;
        }
        public static string PathUpdater(string path, string url)
        {
            var currentDirectory = path.Substring(path.LastIndexOf('\\') + 1);
            var directory = url.Substring(url.LastIndexOf('/') + 1);

            var fullPath = string.Empty;
            if (currentDirectory != directory)
            {
                fullPath = $"{path}\\{directory}";
            }
            else
            {
                fullPath = path;
            }
            
            return fullPath;
        }

        public static bool IsRepositoryCloned(string path)
        {
            return Directory.Exists($"{path}\\.git");
        }
    }
}
