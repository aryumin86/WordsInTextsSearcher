using Microsoft.EntityFrameworkCore.Migrations;

namespace WordsInTextsSearcher.Migrations
{
    public partial class addedTextAttrsBindings3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TextRecordId",
                table: "TextAttrBindings",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TextAttrBindings_TextRecordId",
                table: "TextAttrBindings",
                column: "TextRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_TextAttrBindings_TextRecords_TextRecordId",
                table: "TextAttrBindings",
                column: "TextRecordId",
                principalTable: "TextRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TextAttrBindings_TextRecords_TextRecordId",
                table: "TextAttrBindings");

            migrationBuilder.DropIndex(
                name: "IX_TextAttrBindings_TextRecordId",
                table: "TextAttrBindings");

            migrationBuilder.DropColumn(
                name: "TextRecordId",
                table: "TextAttrBindings");
        }
    }
}
