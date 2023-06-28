using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommonAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserPwdAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PwdHash",
                table: "users",
                type: "BLOB",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PwsSalt",
                table: "users",
                type: "BLOB",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PwdHash",
                table: "users");

            migrationBuilder.DropColumn(
                name: "PwsSalt",
                table: "users");
        }
    }
}
