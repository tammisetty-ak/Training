using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieShopInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingMoviesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movies",
                type: "varchar(200)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Movies",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldNullable: true);
        }
    }
}
