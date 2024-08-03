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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
