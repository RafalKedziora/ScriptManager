using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class addPathToProgramField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PathToRunProgram",
                table: "GitRepoInfo",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "GitRepoInfo",
                keyColumn: "Id",
                keyValue: 1,
                column: "PathToRunProgram",
                value: "C:\\Users\\rawci\\AppData\\Local\\Obsidian\\Obsidian.exe");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PathToRunProgram",
                table: "GitRepoInfo");
        }
    }
}
