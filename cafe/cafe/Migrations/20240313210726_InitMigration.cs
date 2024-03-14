using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cafe.Migrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catgeories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catgeories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MealEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealEntity_Catgeories_CategoryEntityId",
                        column: x => x.CategoryEntityId,
                        principalTable: "Catgeories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealEntity_CategoryEntityId",
                table: "MealEntity",
                column: "CategoryEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealEntity");

            migrationBuilder.DropTable(
                name: "Catgeories");
        }
    }
}
