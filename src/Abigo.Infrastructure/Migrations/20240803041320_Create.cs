using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Abigo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Accountables",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    contactEmail = table.Column<string>(type: "text", nullable: false),
                    contactPhone = table.Column<string>(type: "text", nullable: false),
                    instagram = table.Column<string>(type: "text", nullable: false),
                    ConnectionEmail = table.Column<string>(type: "text", nullable: false),
                    AccessPassword = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accountables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DisponibleLocales",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    AccountId = table.Column<string>(type: "text", nullable: false),
                    PostalCode = table.Column<string>(type: "text", nullable: false),
                    City = table.Column<string>(type: "text", nullable: false),
                    UF = table.Column<int>(type: "integer", nullable: false),
                    NeighboorHood = table.Column<string>(type: "text", nullable: false),
                    Street = table.Column<string>(type: "text", nullable: false),
                    LocaleNumber = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    AcceptsAnimals = table.Column<bool>(type: "boolean", nullable: false),
                    VacanciesNumber = table.Column<int>(type: "integer", nullable: false),
                    contactEmail = table.Column<string>(type: "text", nullable: false),
                    contactPhone = table.Column<string>(type: "text", nullable: false),
                    instagram = table.Column<string>(type: "text", nullable: false),
                    DonationKey = table.Column<string>(type: "text", nullable: false),
                    ReferencePoint = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DisponibleLocales", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accountables");

            migrationBuilder.DropTable(
                name: "DisponibleLocales");
        }
    }
}
