using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOVIE.PREFERENCES.REPO.Migrations
{
    /// <inheritdoc />
    public partial class SEGUNDODB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Movie",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Movie");

            migrationBuilder.RenameTable(
                name: "Movie",
                newName: "Usuario");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Usuario",
                newName: "Nombre");

            migrationBuilder.RenameColumn(
                name: "Genero",
                table: "Usuario",
                newName: "Descripcion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UsuarioRepoDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRepoDto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeneroRepoDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioRepoDtoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneroRepoDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneroRepoDto_UsuarioRepoDto_UsuarioRepoDtoId",
                        column: x => x.UsuarioRepoDtoId,
                        principalTable: "UsuarioRepoDto",
                        principalColumn: "Id");
                });

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
                        name: "FK_GeneroRepoDtoMovieRepoDto_GeneroRepoDto_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "GeneroRepoDto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneroRepoDtoMovieRepoDto_Usuario_PeliculasId",
                        column: x => x.PeliculasId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneroRepoDto_UsuarioRepoDtoId",
                table: "GeneroRepoDto",
                column: "UsuarioRepoDtoId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneroRepoDtoMovieRepoDto_PeliculasId",
                table: "GeneroRepoDtoMovieRepoDto",
                column: "PeliculasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneroRepoDtoMovieRepoDto");

            migrationBuilder.DropTable(
                name: "GeneroRepoDto");

            migrationBuilder.DropTable(
                name: "UsuarioRepoDto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Movie");

            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "Movie",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Movie",
                newName: "Genero");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movie",
                table: "Movie",
                column: "Id");
        }
    }
}
