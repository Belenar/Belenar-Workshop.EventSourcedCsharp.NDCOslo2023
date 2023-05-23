using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeerSender.Web.Migrations
{
    /// <inheritdoc />
    public partial class Add_computed_rowversion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Row_version_long",
                table: "Events",
                type: "bigint",
                nullable: false,
                computedColumnSql: "CONVERT (BIGINT, [Row_version])",
                stored: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Row_version_long",
                table: "Events");
        }
    }
}
