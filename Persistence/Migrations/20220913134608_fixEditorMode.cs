using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class fixEditorMode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "editorMode",
                table: "EditorMode",
                newName: "IsEditorModeActive");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EditorMode",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EditorMode",
                table: "EditorMode",
                column: "Id");

            migrationBuilder.InsertData(
                table: "EditorMode",
                columns: new[] { "Id", "IsEditorModeActive" },
                values: new object[] { 1, true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EditorMode",
                table: "EditorMode");

            migrationBuilder.DeleteData(
                table: "EditorMode",
                keyColumn: "Id",
                keyColumnType: "INTEGER",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EditorMode");

            migrationBuilder.RenameColumn(
                name: "IsEditorModeActive",
                table: "EditorMode",
                newName: "editorMode");
        }
    }
}
