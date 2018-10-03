using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mailie.Migrations
{
    public partial class AddMailContacts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MailContact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreationDateTime = table.Column<DateTime>(nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailContact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MailAddress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreationDateTime = table.Column<DateTime>(nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    MailContactId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MailAddress_MailContact_MailContactId",
                        column: x => x.MailContactId,
                        principalTable: "MailContact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MailAddress_MailContactId",
                table: "MailAddress",
                column: "MailContactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MailAddress");

            migrationBuilder.DropTable(
                name: "MailContact");
        }
    }
}
