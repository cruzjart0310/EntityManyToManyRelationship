using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiTest.Migrations
{
    public partial class AddCatalogType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Question",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Identifider = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Question_TypeId",
                table: "Question",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Question_Type_TypeId",
                table: "Question",
                column: "TypeId",
                principalTable: "Type",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Question_Type_TypeId",
                table: "Question");

            migrationBuilder.DropTable(
                name: "Type");

            migrationBuilder.DropIndex(
                name: "IX_Question_TypeId",
                table: "Question");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Question");
        }
    }
}
