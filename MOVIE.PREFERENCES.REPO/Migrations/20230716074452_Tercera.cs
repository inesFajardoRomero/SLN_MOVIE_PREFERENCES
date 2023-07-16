using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOVIE.PREFERENCES.REPO.Migrations
{
    /// <inheritdoc />
    public partial class Tercera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneroRepoDto_UsuarioRepoDto_UsuarioRepoDtoId",
                table: "GeneroRepoDto");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneroRepoDtoMovieRepoDto_GeneroRepoDto_GeneroId",
                table: "GeneroRepoDtoMovieRepoDto");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneroRepoDtoMovieRepoDto_Usuario_PeliculasId",
                table: "GeneroRepoDtoMovieRepoDto");

            migrationBuilder.DropTable(
                name: "UsuarioRepoDto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GeneroRepoDto",
                table: "GeneroRepoDto");

            migrationBuilder.RenameTable(
                name: "GeneroRepoDto",
                newName: "Genero");

            migrationBuilder.RenameColumn(
                name: "ImagenPoster",
                table: "Usuario",
                newName: "Usuario");

            migrationBuilder.RenameColumn(
                name: "Imagen",
                table: "Usuario",
                newName: "Correo");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Usuario",
                newName: "Contrasena");

            migrationBuilder.RenameIndex(
                name: "IX_GeneroRepoDto_UsuarioRepoDtoId",
                table: "Genero",
                newName: "IX_Genero_UsuarioRepoDtoId");

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genero",
                table: "Genero",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Pelicula",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagenPoster = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pelicula", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Genero_Usuario_UsuarioRepoDtoId",
                table: "Genero",
                column: "UsuarioRepoDtoId",
                principalTable: "Usuario",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneroRepoDtoMovieRepoDto_Genero_GeneroId",
                table: "GeneroRepoDtoMovieRepoDto",
                column: "GeneroId",
                principalTable: "Genero",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneroRepoDtoMovieRepoDto_Pelicula_PeliculasId",
                table: "GeneroRepoDtoMovieRepoDto",
                column: "PeliculasId",
                principalTable: "Pelicula",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Genero_Usuario_UsuarioRepoDtoId",
                table: "Genero");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneroRepoDtoMovieRepoDto_Genero_GeneroId",
                table: "GeneroRepoDtoMovieRepoDto");

            migrationBuilder.DropForeignKey(
                name: "FK_GeneroRepoDtoMovieRepoDto_Pelicula_PeliculasId",
                table: "GeneroRepoDtoMovieRepoDto");

            migrationBuilder.DropTable(
                name: "Pelicula");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genero",
                table: "Genero");

            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "Usuario");

            migrationBuilder.RenameTable(
                name: "Genero",
                newName: "GeneroRepoDto");

            migrationBuilder.RenameColumn(
                name: "Usuario",
                table: "Usuario",
                newName: "ImagenPoster");

            migrationBuilder.RenameColumn(
                name: "Correo",
                table: "Usuario",
                newName: "Imagen");

            migrationBuilder.RenameColumn(
                name: "Contrasena",
                table: "Usuario",
                newName: "Descripcion");

            migrationBuilder.RenameIndex(
                name: "IX_Genero_UsuarioRepoDtoId",
                table: "GeneroRepoDto",
                newName: "IX_GeneroRepoDto_UsuarioRepoDtoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GeneroRepoDto",
                table: "GeneroRepoDto",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UsuarioRepoDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contrasena = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRepoDto", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_GeneroRepoDto_UsuarioRepoDto_UsuarioRepoDtoId",
                table: "GeneroRepoDto",
                column: "UsuarioRepoDtoId",
                principalTable: "UsuarioRepoDto",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneroRepoDtoMovieRepoDto_GeneroRepoDto_GeneroId",
                table: "GeneroRepoDtoMovieRepoDto",
                column: "GeneroId",
                principalTable: "GeneroRepoDto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneroRepoDtoMovieRepoDto_Usuario_PeliculasId",
                table: "GeneroRepoDtoMovieRepoDto",
                column: "PeliculasId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
