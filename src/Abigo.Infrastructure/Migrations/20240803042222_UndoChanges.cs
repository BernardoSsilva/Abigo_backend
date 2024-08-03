using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abigo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UndoChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvailableLocales_Accountables_AccountId",
                table: "AvailableLocales");

            migrationBuilder.DropIndex(
                name: "IX_AvailableLocales_AccountId",
                table: "AvailableLocales");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AvailableLocales_AccountId",
                table: "AvailableLocales",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_AvailableLocales_Accountables_AccountId",
                table: "AvailableLocales",
                column: "AccountId",
                principalTable: "Accountables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
