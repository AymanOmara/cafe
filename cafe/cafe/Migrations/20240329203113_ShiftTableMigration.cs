using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cafe.Migrations
{
    /// <inheritdoc />
    public partial class ShiftTableMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ShiftEntity_ShiftEntityId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShiftEntity",
                table: "ShiftEntity");

            migrationBuilder.RenameTable(
                name: "ShiftEntity",
                newName: "Shifts");

            migrationBuilder.RenameColumn(
                name: "IsHospitality",
                table: "Orders",
                newName: "IsGuest");

            migrationBuilder.RenameColumn(
                name: "HospitalityReason",
                table: "Orders",
                newName: "GuestReason");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "TableId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "Shifts",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Shifts",
                table: "Shifts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TableId",
                table: "Orders",
                column: "TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Shifts_ShiftEntityId",
                table: "Orders",
                column: "ShiftEntityId",
                principalTable: "Shifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Tables_TableId",
                table: "Orders",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Shifts_ShiftEntityId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Tables_TableId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_TableId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Shifts",
                table: "Shifts");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TableId",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Shifts",
                newName: "ShiftEntity");

            migrationBuilder.RenameColumn(
                name: "IsGuest",
                table: "Orders",
                newName: "IsHospitality");

            migrationBuilder.RenameColumn(
                name: "GuestReason",
                table: "Orders",
                newName: "HospitalityReason");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "ShiftEntity",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShiftEntity",
                table: "ShiftEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ShiftEntity_ShiftEntityId",
                table: "Orders",
                column: "ShiftEntityId",
                principalTable: "ShiftEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
