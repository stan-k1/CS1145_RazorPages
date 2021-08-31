using Microsoft.EntityFrameworkCore.Migrations;

namespace CS1145_RazorPages.Migrations
{
    public partial class seedActors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 1, "Bette", "Davis" });

            migrationBuilder.InsertData(
                table: "Actor",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[] { 2, "Anne", "Baxter" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Genre", "Title" },
                values: new object[] { 1, "Margo, an established theater actress, appoints Eve, an aspiring actress, as her personal assistant.", "Joseph L. Mankiewicz", 3, "All About Eve" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Actor",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
