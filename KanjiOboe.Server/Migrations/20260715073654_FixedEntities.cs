using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KanjiOboe.Server.Migrations
{
    /// <inheritdoc />
    public partial class FixedEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Kanji",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Meaning",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "Romaji",
                table: "Cards",
                newName: "Front");

            migrationBuilder.RenameColumn(
                name: "Reading",
                table: "Cards",
                newName: "Back");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Decks",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Cards",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ReviewAt",
                table: "Cards",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Email",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Decks");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "ReviewAt",
                table: "Cards");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "Front",
                table: "Cards",
                newName: "Romaji");

            migrationBuilder.RenameColumn(
                name: "Back",
                table: "Cards",
                newName: "Reading");

            migrationBuilder.AddColumn<string>(
                name: "Kanji",
                table: "Cards",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Meaning",
                table: "Cards",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
