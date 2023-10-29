using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankTest.Migrations
{
    /// <inheritdoc />
    public partial class EditNamePerperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PassWord",
                table: "Users",
                newName: "Password");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "PassWord");
        }
    }
}
