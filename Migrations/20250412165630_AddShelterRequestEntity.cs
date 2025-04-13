using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelPaw.Migrations
{
    /// <inheritdoc />
    public partial class AddShelterRequestEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShelterRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AnimalType = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Age = table.Column<int>(type: "integer", nullable: true),
                    Gender = table.Column<string>(type: "text", nullable: true),
                    Size = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    IsVaccinated = table.Column<bool>(type: "boolean", nullable: true),
                    IsSterilized = table.Column<bool>(type: "boolean", nullable: true),
                    Condition = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    VolunteerId = table.Column<Guid>(type: "uuid", nullable: false),
                    ShelterId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelterRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShelterRequests_Users_ShelterId",
                        column: x => x.ShelterId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShelterRequests_Users_VolunteerId",
                        column: x => x.VolunteerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShelterRequests_ShelterId",
                table: "ShelterRequests",
                column: "ShelterId");

            migrationBuilder.CreateIndex(
                name: "IX_ShelterRequests_VolunteerId",
                table: "ShelterRequests",
                column: "VolunteerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShelterRequests");
        }
    }
}
