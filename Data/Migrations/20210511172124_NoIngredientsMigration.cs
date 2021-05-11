using Microsoft.EntityFrameworkCore.Migrations;

namespace WNWN.Migrations
{
    public partial class NoIngredientsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NoIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoIngredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FoodList",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NoIngredientsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodList", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FoodList_NoIngredients_NoIngredientsId",
                        column: x => x.NoIngredientsId,
                        principalTable: "NoIngredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoodList_NoIngredientsId",
                table: "FoodList",
                column: "NoIngredientsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodList");

            migrationBuilder.DropTable(
                name: "NoIngredients");
        }
    }
}
