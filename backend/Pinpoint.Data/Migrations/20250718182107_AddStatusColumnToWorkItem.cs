using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pinpoint.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusColumnToWorkItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "WorkItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "WorkItems");
        }
    }
}
