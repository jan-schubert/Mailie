using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mailie.Migrations
{
    public partial class CreateInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MailAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreationDateTime = table.Column<DateTime>(nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(nullable: false),
                    Host = table.Column<string>(nullable: true),
                    Port = table.Column<int>(nullable: false),
                    SecureSocketOptions = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailAccounts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MailAccounts");
        }
    }
}
