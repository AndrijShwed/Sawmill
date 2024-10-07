using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sawmill.Migrations
{
    /// <inheritdoc />
    public partial class PriceAddTwoPrices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Ціна",
                table: "Prices",
                newName: "ЦінаЦиліндр");

            migrationBuilder.AlterColumn<string>(
                name: "Дата",
                table: "Prices",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "ЦінаПиломатеріал",
                table: "Prices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ЦінаПиломатеріал",
                table: "Prices");

            migrationBuilder.RenameColumn(
                name: "ЦінаЦиліндр",
                table: "Prices",
                newName: "Ціна");

            migrationBuilder.UpdateData(
                table: "Prices",
                keyColumn: "Дата",
                keyValue: null,
                column: "Дата",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Дата",
                table: "Prices",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
