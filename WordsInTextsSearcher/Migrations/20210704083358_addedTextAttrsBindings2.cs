using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace WordsInTextsSearcher.Migrations
{
    public partial class addedTextAttrsBindings2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TextAttrBindings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AttributeId = table.Column<int>(type: "integer", nullable: false),
                    AttributeValueId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextAttrBindings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextAttrBindings_TextAttributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "TextAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TextAttrBindings_TextAttributeValues_AttributeValueId",
                        column: x => x.AttributeValueId,
                        principalTable: "TextAttributeValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TextAttrBindings_AttributeId",
                table: "TextAttrBindings",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_TextAttrBindings_AttributeValueId",
                table: "TextAttrBindings",
                column: "AttributeValueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TextAttrBindings");
        }
    }
}
