using Microsoft.EntityFrameworkCore.Migrations;

namespace WordsInTextsSearcher.Migrations
{
    public partial class addedTextAttrsBindings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TextRecordId",
                table: "TextAttributes",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TextAttributes_TextRecordId",
                table: "TextAttributes",
                column: "TextRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_TextAttributes_TextRecords_TextRecordId",
                table: "TextAttributes",
                column: "TextRecordId",
                principalTable: "TextRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TextAttributes_TextRecords_TextRecordId",
                table: "TextAttributes");

            migrationBuilder.DropIndex(
                name: "IX_TextAttributes_TextRecordId",
                table: "TextAttributes");

            migrationBuilder.DropColumn(
                name: "TextRecordId",
                table: "TextAttributes");
        }
    }
}
