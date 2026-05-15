using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project5Day.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class mig_match_event_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ActionType",
                table: "MatchEvents",
                newName: "EventType");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventType",
                table: "MatchEvents",
                newName: "ActionType");
        }
    }
}
