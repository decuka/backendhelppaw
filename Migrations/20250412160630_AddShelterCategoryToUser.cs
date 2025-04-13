using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelPaw.Migrations
{
    /// <inheritdoc />
    public partial class AddShelterCategoryToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShelterCategory",
                table: "Users",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShelterCategory",
                table: "Users");
        }
    }
}
