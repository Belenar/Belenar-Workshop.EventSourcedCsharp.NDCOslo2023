using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeerSender.Web.Migrations
{
    /// <inheritdoc />
    public partial class Rename_row_version : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RowVersion",
                table: "Events",
                newName: "Row_version");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Row_version",
                table: "Events",
                newName: "RowVersion");
        }
    }
}
