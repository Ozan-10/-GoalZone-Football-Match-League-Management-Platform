using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project5Day.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_team_logo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Teams",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Teams");
        }
    }
}
