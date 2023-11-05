using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Пилорама.Migrations
{
    /// <inheritdoc />
    public partial class _486 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Numbers",
                newName: "Номер_телефону");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Numbers",
                newName: "Населений_пункт");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Numbers",
                newName: "Ім_я");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Номер_телефону",
                table: "Numbers",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Населений_пункт",
                table: "Numbers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Ім_я",
                table: "Numbers",
                newName: "Address");
        }
    }
}
