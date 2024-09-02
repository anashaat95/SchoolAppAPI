using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshTokenTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Token",
                schema: "dbo",
                table: "UserRefreshTokens",
                newName: "RefreshToken");

            migrationBuilder.AddColumn<string>(
                name: "AccessToken",
                schema: "dbo",
                table: "UserRefreshTokens",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessToken",
                schema: "dbo",
                table: "UserRefreshTokens");

            migrationBuilder.RenameColumn(
                name: "RefreshToken",
                schema: "dbo",
                table: "UserRefreshTokens",
                newName: "Token");
        }
    }
}
