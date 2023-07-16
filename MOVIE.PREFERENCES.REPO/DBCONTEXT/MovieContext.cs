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

        public DbSet<MovieRepoDto> MovieRepoDto { get; set; }

        public DbSet<GeneroRepoDto> GeneroRepoDto { get; set; }

        public DbSet<UsuarioRepoDto> UsuarioRepoDto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<MovieRepoDto>().ToTable("Pelicula");
            modelBuilder.Entity<GeneroRepoDto>().ToTable("Genero");
            modelBuilder.Entity<UsuarioRepoDto>().ToTable("Usuario");
        }
    }
}
