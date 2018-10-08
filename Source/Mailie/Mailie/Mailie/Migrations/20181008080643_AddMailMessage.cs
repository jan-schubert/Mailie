using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mailie.Migrations
{
    public partial class AddMailMessage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MailMessage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreationDateTime = table.Column<DateTime>(nullable: false),
                    LastModifiedDateTime = table.Column<DateTime>(nullable: false),
                    MailContactId = table.Column<int>(nullable: true),
                    Bcc = table.Column<string>(nullable: true),
                    BodyText = table.Column<string>(nullable: true),
                    Cc = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    From = table.Column<string>(nullable: true),
                    HtmlBody = table.Column<string>(nullable: true),
                    MessageImportance = table.Column<int>(nullable: false),
                    InReplyTo = table.Column<string>(nullable: true),
                    MessageId = table.Column<string>(nullable: true),
                    MimeVersion = table.Column<string>(nullable: true),
                    MessagePriority = table.Column<int>(nullable: false),
                    ReplyTo = table.Column<string>(nullable: true),
                    ResentBcc = table.Column<string>(nullable: true),
                    ResentCc = table.Column<string>(nullable: true),
                    ResentDate = table.Column<DateTime>(nullable: false),
                    ResentFrom = table.Column<string>(nullable: true),
                    ResentMessageId = table.Column<string>(nullable: true),
                    ResentReplyTo = table.Column<string>(nullable: true),
                    ResentSender = table.Column<string>(nullable: true),
                    ResentTo = table.Column<string>(nullable: true),
                    Sender = table.Column<string>(nullable: true),
                    Subject = table.Column<string>(nullable: true),
                    TextBody = table.Column<string>(nullable: true),
                    To = table.Column<string>(nullable: true),
                    XPriority = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MailMessage_MailContact_MailContactId",
                        column: x => x.MailContactId,
                        principalTable: "MailContact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MailMessage_MailContactId",
                table: "MailMessage",
                column: "MailContactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MailMessage");
        }
    }
}
