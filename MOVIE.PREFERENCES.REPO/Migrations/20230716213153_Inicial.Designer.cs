﻿// <auto-generated />
using MOVIE.PREFERENCES.REPO.DBCONTEXT;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MOVIE.PREFERENCES.REPO.Migrations
{
    [DbContext(typeof(MovieContext))]
    [Migration("20230716213153_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MOVIE.PREFERENCES.REPO.MODELS.GeneroRepoDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genero", (string)null);
                });

            modelBuilder.Entity("MOVIE.PREFERENCES.REPO.MODELS.PeliculaGeneroRepoDto", b =>
                {
                    b.Property<int>("PeliculaId")
                        .HasColumnType("int");

                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.HasKey("PeliculaId", "GeneroId");

                    b.HasIndex("GeneroId");

                    b.ToTable("PeliculaGenero", (string)null);
                });

            modelBuilder.Entity("MOVIE.PREFERENCES.REPO.MODELS.PeliculaRepoDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagenPoster")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pelicula", (string)null);
                });

            modelBuilder.Entity("MOVIE.PREFERENCES.REPO.MODELS.UsuarioGeneroRepoDto", b =>
                {
                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.Property<int>("GeneroId")
                        .HasColumnType("int");

                    b.HasKey("UsuarioId", "GeneroId");

                    b.HasIndex("GeneroId");

                    b.ToTable("UsuarioGenero", (string)null);
                });

            modelBuilder.Entity("MOVIE.PREFERENCES.REPO.MODELS.UsuarioRepoDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuario", (string)null);
                });

            modelBuilder.Entity("MOVIE.PREFERENCES.REPO.MODELS.PeliculaGeneroRepoDto", b =>
                {
                    b.HasOne("MOVIE.PREFERENCES.REPO.MODELS.GeneroRepoDto", "Genero")
                        .WithMany("PeliculaGenero")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MOVIE.PREFERENCES.REPO.MODELS.PeliculaRepoDto", "Pelicula")
                        .WithMany("PeliculaGenero")
                        .HasForeignKey("PeliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genero");

                    b.Navigation("Pelicula");
                });

            modelBuilder.Entity("MOVIE.PREFERENCES.REPO.MODELS.UsuarioGeneroRepoDto", b =>
                {
                    b.HasOne("MOVIE.PREFERENCES.REPO.MODELS.GeneroRepoDto", "Genero")
                        .WithMany("UsuarioGenero")
                        .HasForeignKey("GeneroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MOVIE.PREFERENCES.REPO.MODELS.UsuarioRepoDto", "Usuario")
                        .WithMany("UsuarioGenero")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genero");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("MOVIE.PREFERENCES.REPO.MODELS.GeneroRepoDto", b =>
                {
                    b.Navigation("PeliculaGenero");

                    b.Navigation("UsuarioGenero");
                });

            modelBuilder.Entity("MOVIE.PREFERENCES.REPO.MODELS.PeliculaRepoDto", b =>
                {
                    b.Navigation("PeliculaGenero");
                });

            modelBuilder.Entity("MOVIE.PREFERENCES.REPO.MODELS.UsuarioRepoDto", b =>
                {
                    b.Navigation("UsuarioGenero");
                });
#pragma warning restore 612, 618
        }
    }
}