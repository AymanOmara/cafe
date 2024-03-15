using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cafe.Migrations
{
    /// <inheritdoc />
    public partial class AddDeliverdPapersToEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DeliverdPapers",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliverdPapers",
                table: "Employees");
        }
    }
}
