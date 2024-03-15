using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cafe.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMealTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealEntity_Catgeories_CategoryEntityId",
                table: "MealEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MealEntity",
                table: "MealEntity");

            migrationBuilder.RenameTable(
                name: "MealEntity",
                newName: "Meals");

            migrationBuilder.RenameIndex(
                name: "IX_MealEntity_CategoryEntityId",
                table: "Meals",
                newName: "IX_Meals_CategoryEntityId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Meals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Meals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Meals",
                table: "Meals",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Catgeories_CategoryEntityId",
                table: "Meals",
                column: "CategoryEntityId",
                principalTable: "Catgeories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Catgeories_CategoryEntityId",
                table: "Meals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Meals",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Meals");

            migrationBuilder.RenameTable(
                name: "Meals",
                newName: "MealEntity");

            migrationBuilder.RenameIndex(
                name: "IX_Meals_CategoryEntityId",
                table: "MealEntity",
                newName: "IX_MealEntity_CategoryEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealEntity",
                table: "MealEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MealEntity_Catgeories_CategoryEntityId",
                table: "MealEntity",
                column: "CategoryEntityId",
                principalTable: "Catgeories",
                principalColumn: "Id");
        }
    }
}
