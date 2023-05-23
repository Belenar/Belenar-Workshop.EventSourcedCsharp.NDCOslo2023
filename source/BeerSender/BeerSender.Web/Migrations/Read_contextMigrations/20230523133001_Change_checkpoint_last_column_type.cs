using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BeerSender.Web.Migrations.Read_contextMigrations
{
    /// <inheritdoc />
    public partial class Change_checkpoint_last_column_type : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Last_timestamp",
                table: "Checkpoints",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "binary(8)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Last_timestamp",
                table: "Checkpoints",
                type: "binary(8)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }
    }
}
