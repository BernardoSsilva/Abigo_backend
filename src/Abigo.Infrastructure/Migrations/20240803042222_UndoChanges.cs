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
                name: "FK_DisponibleLocales_Accountables_AccountId",
                table: "DisponibleLocales");

            migrationBuilder.DropIndex(
                name: "IX_DisponibleLocales_AccountId",
                table: "DisponibleLocales");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_DisponibleLocales_AccountId",
                table: "DisponibleLocales",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_DisponibleLocales_Accountables_AccountId",
                table: "DisponibleLocales",
                column: "AccountId",
                principalTable: "Accountables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
