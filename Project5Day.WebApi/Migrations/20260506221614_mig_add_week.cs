using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project5Day.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_week : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Week",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Week",
                table: "Matches");
        }
    }
}
