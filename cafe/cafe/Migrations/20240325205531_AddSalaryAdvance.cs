using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cafe.Migrations
{
    /// <inheritdoc />
    public partial class AddSalaryAdvance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Closed",
                table: "SalaryItemEntity",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PayAdvance_EmployeeEntityId",
                table: "SalaryItemEntity",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalaryItemEntity_PayAdvance_EmployeeEntityId",
                table: "SalaryItemEntity",
                column: "PayAdvance_EmployeeEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalaryItemEntity_Employees_PayAdvance_EmployeeEntityId",
                table: "SalaryItemEntity",
                column: "PayAdvance_EmployeeEntityId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalaryItemEntity_Employees_PayAdvance_EmployeeEntityId",
                table: "SalaryItemEntity");

            migrationBuilder.DropIndex(
                name: "IX_SalaryItemEntity_PayAdvance_EmployeeEntityId",
                table: "SalaryItemEntity");

            migrationBuilder.DropColumn(
                name: "Closed",
                table: "SalaryItemEntity");

            migrationBuilder.DropColumn(
                name: "PayAdvance_EmployeeEntityId",
                table: "SalaryItemEntity");
        }
    }
}
