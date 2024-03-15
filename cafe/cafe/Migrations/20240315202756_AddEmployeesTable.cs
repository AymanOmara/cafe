using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cafe.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployeesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BaseSalary = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalaryItemEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    SalaryDeductionEntity_EmployeeEntityId = table.Column<int>(type: "int", nullable: true),
                    EmployeeEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryItemEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalaryItemEntity_Employees_EmployeeEntityId",
                        column: x => x.EmployeeEntityId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SalaryItemEntity_Employees_SalaryDeductionEntity_EmployeeEntityId",
                        column: x => x.SalaryDeductionEntity_EmployeeEntityId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalaryItemEntity_EmployeeEntityId",
                table: "SalaryItemEntity",
                column: "EmployeeEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryItemEntity_SalaryDeductionEntity_EmployeeEntityId",
                table: "SalaryItemEntity",
                column: "SalaryDeductionEntity_EmployeeEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalaryItemEntity");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
