using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Пилорама.Data.Migrations
{
    /// <inheritdoc />
    public partial class FolderWork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Client",
                table: "Work",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "OrderNumber",
                table: "Work",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WorkId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Client",
                table: "Work");

            migrationBuilder.DropColumn(
                name: "OrderNumber",
                table: "Work");

            migrationBuilder.DropColumn(
                name: "WorkId",
                table: "Orders");
        }
    }
}
