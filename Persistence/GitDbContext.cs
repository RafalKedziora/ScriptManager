using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class GitDbContext : DbContext
    {
        public GitDbContext(DbContextOptions<GitDbContext> options) : base(options)
        {
        }

        public DbSet<GitRepoInfo> GitRepoInfos { get; set; }
        public DbSet<EditorMode> EditorModes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GitRepoInfo>(x =>
            {
                x.ToTable("GitRepoInfo");
                x.HasKey(x => x.Id);
                x.Property(x => x.UrlToRepository).IsRequired();
                x.Property(x => x.PathToFile).IsRequired();

                x.HasData(new GitRepoInfo 
                { 
                    Id = 1, 
                    PathToFile = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\source\\repos\\", 
                    UrlToRepository = "https://github.com/RafalKedziora/test",
                    PathToRunProgram = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\AppData\\Local\\Obsidian\\Obsidian.exe"
                });
            });

            modelBuilder.Entity<EditorMode>(x =>
            {
                x.HasKey(x => x.Id);
                x.ToTable("EditorMode");

                x.HasData(new EditorMode
                {
                    Id = 1,
                    IsEditorModeActive = true
                });
            });
        }
    }
}
