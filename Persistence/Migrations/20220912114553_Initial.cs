using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GitRepoInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PathToFile = table.Column<string>(type: "TEXT", nullable: false),
                    UrlToRepository = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GitRepoInfo", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "GitRepoInfo",
                columns: new[] { "Id", "PathToFile", "UrlToRepository" },
                values: new object[] { 1, "C:\\Users\\rawci\\source\\repos\\", "https://github.com/RafalKedziora/test" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GitRepoInfo");
        }
    }
}
