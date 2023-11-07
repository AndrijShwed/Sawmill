using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Пилорама.Migrations
{
    /// <inheritdoc />
    public partial class _0321 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Замовник",
                table: "Numbers",
                newName: "Замовник1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Замовник1",
                table: "Numbers",
                newName: "Замовник");
        }
    }
}
