using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerOperatorDatabaseApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Operators_OperatorId",
                table: "Customers");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Operators_OperatorId",
                table: "Customers",
                column: "OperatorId",
                principalTable: "Operators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Operators_OperatorId",
                table: "Customers");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Operators_OperatorId",
                table: "Customers",
                column: "OperatorId",
                principalTable: "Operators",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
