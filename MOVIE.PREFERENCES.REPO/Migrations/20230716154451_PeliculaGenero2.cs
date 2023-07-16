using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOVIE.PREFERENCES.REPO.Migrations
{
    /// <inheritdoc />
    public partial class PeliculaGenero2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PeliculaGenero",
                table: "PeliculaGenero");

            migrationBuilder.DropIndex(
                name: "IX_PeliculaGenero_PeliculaId",
                table: "PeliculaGenero");

            migrationBuilder.DropColumn(
                name: "IdGenero",
                table: "PeliculaGenero");

            migrationBuilder.DropColumn(
                name: "IdPelicula",
                table: "PeliculaGenero");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PeliculaGenero",
                table: "PeliculaGenero",
                columns: new[] { "PeliculaId", "GeneroId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PeliculaGenero",
                table: "PeliculaGenero");

            migrationBuilder.AddColumn<string>(
                name: "IdGenero",
                table: "PeliculaGenero",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "IdPelicula",
                table: "PeliculaGenero",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PeliculaGenero",
                table: "PeliculaGenero",
                columns: new[] { "IdGenero", "IdPelicula" });

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaGenero_PeliculaId",
                table: "PeliculaGenero",
                column: "PeliculaId");
        }
    }
}
