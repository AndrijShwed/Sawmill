using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Пилорама.Migrations
{
    /// <inheritdoc />
    public partial class _888 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Numbers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Numbers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Numbers");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Numbers");
        }
    }
}
