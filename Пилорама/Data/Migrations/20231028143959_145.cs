using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Пилорама.Data.Migrations
{
    /// <inheritdoc />
    public partial class _145 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "weight",
                table: "Orders",
                newName: "Ширина");

            migrationBuilder.RenameColumn(
                name: "volume",
                table: "Orders",
                newName: "Сума");

            migrationBuilder.RenameColumn(
                name: "sum",
                table: "Orders",
                newName: "Об_єм");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Orders",
                newName: "Ціна");

            migrationBuilder.RenameColumn(
                name: "number",
                table: "Orders",
                newName: "Кількість");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Orders",
                newName: "Назва");

            migrationBuilder.RenameColumn(
                name: "length",
                table: "Orders",
                newName: "Замовник");

            migrationBuilder.RenameColumn(
                name: "height",
                table: "Orders",
                newName: "Довжина");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Orders",
                newName: "Висота");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ширина",
                table: "Orders",
                newName: "weight");

            migrationBuilder.RenameColumn(
                name: "Ціна",
                table: "Orders",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Сума",
                table: "Orders",
                newName: "volume");

            migrationBuilder.RenameColumn(
                name: "Об_єм",
                table: "Orders",
                newName: "sum");

            migrationBuilder.RenameColumn(
                name: "Назва",
                table: "Orders",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Кількість",
                table: "Orders",
                newName: "number");

            migrationBuilder.RenameColumn(
                name: "Замовник",
                table: "Orders",
                newName: "length");

            migrationBuilder.RenameColumn(
                name: "Довжина",
                table: "Orders",
                newName: "height");

            migrationBuilder.RenameColumn(
                name: "Висота",
                table: "Orders",
                newName: "UserId");
        }
    }
}
