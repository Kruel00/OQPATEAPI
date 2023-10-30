using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OQPATE.DB.Migrations
{
    /// <inheritdoc />
    public partial class fixsomeproporties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Saldo",
                table: "Users",
                newName: "Balance");

            migrationBuilder.RenameColumn(
                name: "AdressLine2",
                table: "Users",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "AdreesLine1",
                table: "Users",
                newName: "AddressLine1");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine2",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressLine2",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "Users",
                newName: "AdressLine2");

            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "Users",
                newName: "Saldo");

            migrationBuilder.RenameColumn(
                name: "AddressLine1",
                table: "Users",
                newName: "AdreesLine1");
        }
    }
}
