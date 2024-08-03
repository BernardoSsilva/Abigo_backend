using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abigo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AccountableEntityId",
                table: "AvailableLocales",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AvailableLocales_AccountableEntityId",
                table: "AvailableLocales",
                column: "AccountableEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_AvailableLocales_Accountables_AccountableEntityId",
                table: "AvailableLocales",
                column: "AccountableEntityId",
                principalTable: "Accountables",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvailableLocales_Accountables_AccountableEntityId",
                table: "AvailableLocales");

            migrationBuilder.DropIndex(
                name: "IX_AvailableLocales_AccountableEntityId",
                table: "AvailableLocales");

            migrationBuilder.DropColumn(
                name: "AccountableEntityId",
                table: "AvailableLocales");
        }
    }
}
