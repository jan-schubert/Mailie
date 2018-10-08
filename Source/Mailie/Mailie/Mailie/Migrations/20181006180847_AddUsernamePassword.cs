using Microsoft.EntityFrameworkCore.Migrations;

namespace Mailie.Migrations
{
    public partial class AddUsernamePassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "MailAccounts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "MailAccounts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "MailAccounts");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "MailAccounts");
        }
    }
}
