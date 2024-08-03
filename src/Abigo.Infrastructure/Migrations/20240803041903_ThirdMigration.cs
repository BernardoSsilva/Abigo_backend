using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abigo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisponibleLocales_Accountables_AccountableEntityId",
                table: "DisponibleLocales");

            migrationBuilder.DropIndex(
                name: "IX_DisponibleLocales_AccountableEntityId",
                table: "DisponibleLocales");

            migrationBuilder.DropColumn(
                name: "AccountableEntityId",
                table: "DisponibleLocales");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DisponibleLocales_Accountables_AccountId",
                table: "DisponibleLocales");

            migrationBuilder.DropIndex(
                name: "IX_DisponibleLocales_AccountId",
                table: "DisponibleLocales");

            migrationBuilder.AddColumn<string>(
                name: "AccountableEntityId",
                table: "DisponibleLocales",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DisponibleLocales_AccountableEntityId",
                table: "DisponibleLocales",
                column: "AccountableEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_DisponibleLocales_Accountables_AccountableEntityId",
                table: "DisponibleLocales",
                column: "AccountableEntityId",
                principalTable: "Accountables",
                principalColumn: "Id");
        }
    }
}
