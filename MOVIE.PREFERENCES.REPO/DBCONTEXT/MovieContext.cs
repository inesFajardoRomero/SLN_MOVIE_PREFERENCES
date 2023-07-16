using Microsoft.EntityFrameworkCore;
using MOVIE.PREFERENCES.REPO.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOVIE.PREFERENCES.REPO.DBCONTEXT
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) 
        {

        }

        public MovieContext()
        {

        }

        public DbSet<PeliculaRepoDto> PeliculaRepoDto { get; set; }

        public DbSet<GeneroRepoDto> GeneroRepoDto { get; set; }

        public DbSet<PeliculaGeneroRepoDto> PeliculaGeneroRepoDto { get; set; }

        public DbSet<UsuarioRepoDto> UsuarioRepoDto { get; set; }

        public DbSet<UsuarioGeneroRepoDto> UsuarioGeneroRepoDto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PeliculaRepoDto>().ToTable("Pelicula");
            modelBuilder.Entity<GeneroRepoDto>().ToTable("Genero");
            modelBuilder.Entity<PeliculaGeneroRepoDto>().ToTable("PeliculaGenero");
            modelBuilder.Entity<UsuarioRepoDto>().ToTable("Usuario");
            modelBuilder.Entity<UsuarioGeneroRepoDto>().ToTable("UsuarioGenero");
            modelBuilder.Entity<PeliculaGeneroRepoDto>().HasKey(x => new { x.PeliculaId, x.GeneroId });
            modelBuilder.Entity<UsuarioGeneroRepoDto>().HasKey(x => new { x.UsuarioId, x.GeneroId });
        }
    }
}
