using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Пилорама.Migrations
{
    /// <inheritdoc />
    public partial class _5698745 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Замовник",
                table: "Numbers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Замовник",
                table: "Numbers");
        }
    }
}
