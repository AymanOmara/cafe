using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cafe.Migrations
{
    /// <inheritdoc />
    public partial class RelationBetweenTransactionsAndShift : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShiftId",
                table: "TransactionsEntity",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TransactionsEntity_ShiftId",
                table: "TransactionsEntity",
                column: "ShiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_TransactionsEntity_Shifts_ShiftId",
                table: "TransactionsEntity",
                column: "ShiftId",
                principalTable: "Shifts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TransactionsEntity_Shifts_ShiftId",
                table: "TransactionsEntity");

            migrationBuilder.DropIndex(
                name: "IX_TransactionsEntity_ShiftId",
                table: "TransactionsEntity");

            migrationBuilder.DropColumn(
                name: "ShiftId",
                table: "TransactionsEntity");
        }
    }
}
