using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOVIE.PREFERENCES.REPO.Migrations
{
    /// <inheritdoc />
    public partial class PeliculaGenero : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genero_Usuario_UsuarioRepoDtoId",
                table: "Genero");

            migrationBuilder.DropTable(
                name: "GeneroRepoDtoMovieRepoDto");

            migrationBuilder.DropIndex(
                name: "IX_Genero_UsuarioRepoDtoId",
                table: "Genero");

            migrationBuilder.DropColumn(
                name: "UsuarioRepoDtoId",
                table: "Genero");

            migrationBuilder.CreateTable(
                name: "PeliculaGenero",
                columns: table => new
                {
                    IdPelicula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdGenero = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PeliculaId = table.Column<int>(type: "int", nullable: false),
                    GeneroId = table.Column<int>(type: "int", nullable: false),
                    UsuarioRepoDtoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculaGenero", x => new { x.IdGenero, x.IdPelicula });
                    table.ForeignKey(
                        name: "FK_PeliculaGenero_Genero_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Genero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeliculaGenero_Pelicula_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Pelicula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeliculaGenero_Usuario_UsuarioRepoDtoId",
                        column: x => x.UsuarioRepoDtoId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaGenero_GeneroId",
                table: "PeliculaGenero",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaGenero_PeliculaId",
                table: "PeliculaGenero",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaGenero_UsuarioRepoDtoId",
                table: "PeliculaGenero",
                column: "UsuarioRepoDtoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeliculaGenero");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioRepoDtoId",
                table: "Genero",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GeneroRepoDtoMovieRepoDto",
                columns: table => new
                {
                    GeneroId = table.Column<int>(type: "int", nullable: false),
                    PeliculasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneroRepoDtoMovieRepoDto", x => new { x.GeneroId, x.PeliculasId });
                    table.ForeignKey(
                        name: "FK_GeneroRepoDtoMovieRepoDto_Genero_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Genero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneroRepoDtoMovieRepoDto_Pelicula_PeliculasId",
                        column: x => x.PeliculasId,
                        principalTable: "Pelicula",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Genero_UsuarioRepoDtoId",
                table: "Genero",
                column: "UsuarioRepoDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneroRepoDtoMovieRepoDto_PeliculasId",
                table: "GeneroRepoDtoMovieRepoDto",
                column: "PeliculasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genero_Usuario_UsuarioRepoDtoId",
                table: "Genero",
                column: "UsuarioRepoDtoId",
                principalTable: "Usuario",
                principalColumn: "Id");
        }
    }
}
