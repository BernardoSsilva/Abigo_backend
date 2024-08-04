using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abigo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addictLinkField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LocalizationLink",
                table: "AvailableLocales",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocalizationLink",
                table: "AvailableLocales");
        }
    }
}
