using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieShopInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreatingMovieTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BackdropURL = table.Column<string>(type: "nvarchar(2084)", maxLength: 2084, nullable: true),
                    Budget = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 0m),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()"),
                    ImdbUrl = table.Column<string>(type: "nvarchar(2084)", maxLength: 2084, nullable: true),
                    OriginalLanguage = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: true),
                    PosterUrl = table.Column<string>(type: "nvarchar(2084)", maxLength: 2084, nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(5,2)", nullable: false, defaultValue: 9.9m),
                    Revenue = table.Column<decimal>(type: "decimal(18,4)", nullable: false, defaultValue: 0m),
                    Runtime = table.Column<int>(type: "int", nullable: false),
                    TagLine = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    TmdbUrl = table.Column<string>(type: "nvarchar(2084)", maxLength: 2084, nullable: true),
                    Title = table.Column<string>(type: "varchar(20)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
