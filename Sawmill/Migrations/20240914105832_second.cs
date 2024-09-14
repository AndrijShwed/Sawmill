using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sawmill.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "orderId",
                table: "Orders",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Orders",
                newName: "Дата");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Orders",
                newName: "orderId");

            migrationBuilder.RenameColumn(
                name: "Дата",
                table: "Orders",
                newName: "Date");
        }
    }
}
