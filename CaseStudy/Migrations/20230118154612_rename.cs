using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CaseStudy.Migrations
{
    /// <inheritdoc />
    public partial class rename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "User",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "NoteDetailId",
                table: "NoteDetail",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "NoteId",
                table: "Note",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "NoteDetail",
                newName: "NoteDetailId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Note",
                newName: "NoteId");
        }
    }
}
