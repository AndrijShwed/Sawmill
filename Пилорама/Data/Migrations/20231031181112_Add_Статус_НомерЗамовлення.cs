using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Пилорама.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_Статус_НомерЗамовлення : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "НомерЗамовлення",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Статус",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "НомерЗамовлення",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Статус",
                table: "Orders");
        }
    }
}
