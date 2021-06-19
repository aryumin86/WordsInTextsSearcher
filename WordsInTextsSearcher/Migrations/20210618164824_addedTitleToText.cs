using Microsoft.EntityFrameworkCore.Migrations;

namespace WordsInTextsSearcher.Migrations
{
    public partial class addedTitleToText : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "TextRecords",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "TextRecords");
        }
    }
}
