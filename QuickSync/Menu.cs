using Domain;

namespace ObsidianCustomRuntime
{
    public class Menu
    {
        private readonly GitDbContext context;
        public Menu(GitDbContext context)
        {
            this.context = context;
        }
        
        public Task UseMenu()
        {
            Console.WriteLine("Options:\n1. Update Database Data\n2. Run Obsidian\n3. Turn off Editor Mode\n4. Exit");
            var choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    UpdateData();
                    break;
                case "2":
                    break;
                case "3":
                    TurnOffEditorMode();
                    break;
                default:
                    Console.WriteLine("broken args");
                    return Task.CompletedTask;
            }

            return Task.CompletedTask;
        }

        public Task UpdateData()
        {
            Console.WriteLine("Give path where repo should be cloned(NO destination folder)");
            var path = Console.ReadLine();
            DirectoryHelper.DirectoryCreator(path);
            
            Console.WriteLine("Give url to the github repo (NO from Clone tab)");
            var url = Console.ReadLine();

            var updatedData = new GitRepoInfo { Id = 1, PathToFile = path, UrlToRepository = url };

            context.GitRepoInfos.Update(updatedData);
            context.SaveChanges();

            return Task.CompletedTask;
        }

        public async Task TurnOffEditorMode()
        {
            var editorModeOpposite = new EditorMode 
            { 
                Id = 1,
                IsEditorModeActive = false
            };
            context.EditorModes.Update(editorModeOpposite);
            await context.SaveChangesAsync();
        }
    }
}
