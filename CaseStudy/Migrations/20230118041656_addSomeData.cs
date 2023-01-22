using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CaseStudy.Migrations
{
    /// <inheritdoc />
    public partial class addSomeData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "FullName" },
                values: new object[,]
                {
                    { 1, "Ali" },
                    { 2, "Veli" },
                    { 3, "Cem" }
                });

            migrationBuilder.InsertData(
                table: "Note",
                columns: new[] { "NoteId", "Content", "UserId" },
                values: new object[,]
                {
                    { 1, "Deneme not 1", 1 },
                    { 2, "Deneme not 2", 2 },
                    { 3, "Deneme not 3", 3 }
                });

            migrationBuilder.InsertData(
                table: "NoteDetail",
                columns: new[] { "NoteDetailId", "Content", "NoteId", "UserId" },
                values: new object[,]
                {
                    { 1, "Deneme not detay 1", 1, 1 },
                    { 2, "Deneme not detay 1", 2, 2 },
                    { 3, "Deneme not detay 1", 3, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NoteDetail",
                keyColumn: "NoteDetailId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NoteDetail",
                keyColumn: "NoteDetailId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NoteDetail",
                keyColumn: "NoteDetailId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Note",
                keyColumn: "NoteId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Note",
                keyColumn: "NoteId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Note",
                keyColumn: "NoteId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserId",
                keyValue: 3);
        }
    }
}
