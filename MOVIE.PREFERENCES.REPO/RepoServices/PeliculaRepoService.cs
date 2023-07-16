using MOVIE.PREFERENCES.REPO.DBCONTEXT;
using MOVIE.PREFERENCES.REPO.Interfaces;
using MOVIE.PREFERENCES.REPO.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOVIE.PREFERENCES.REPO.RepoServices
{
    public class PeliculaRepoService : IRepositorio<Int32, MovieRepoDto>
    {
        private readonly MovieContext _context;

        public PeliculaRepoService(MovieContext context) 
        { 
            this._context = context;
        }

        public MovieRepoDto Buscar(int id)
        {
            try
            {
                return _context.MovieRepoDto.Where(x => x.Id == id).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<MovieRepoDto> listar()
        {
            try
            {
                return _context.MovieRepoDto.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
