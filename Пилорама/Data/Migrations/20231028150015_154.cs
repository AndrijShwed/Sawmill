using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Пилорама.Data.Migrations
{
    /// <inheritdoc />
    public partial class _154 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ширина",
                table: "Orders",
                newName: "Ширина_в_мм");

            migrationBuilder.RenameColumn(
                name: "Довжина",
                table: "Orders",
                newName: "Довжина_в_м");

            migrationBuilder.RenameColumn(
                name: "Висота",
                table: "Orders",
                newName: "Висота_в_мм");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ширина_в_мм",
                table: "Orders",
                newName: "Ширина");

            migrationBuilder.RenameColumn(
                name: "Довжина_в_м",
                table: "Orders",
                newName: "Довжина");

            migrationBuilder.RenameColumn(
                name: "Висота_в_мм",
                table: "Orders",
                newName: "Висота");
        }
    }
}
