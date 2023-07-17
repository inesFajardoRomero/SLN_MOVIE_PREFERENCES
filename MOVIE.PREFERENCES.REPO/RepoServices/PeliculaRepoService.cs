using Microsoft.EntityFrameworkCore;
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
    public class PeliculaRepoService : IRepositorio<Int32, PeliculaRepoDto>
    {
        private readonly MovieContext _context;

        public PeliculaRepoService(MovieContext context) 
        { 
            this._context = context;
        }

        public PeliculaRepoDto Add(PeliculaRepoDto entidad)
        {
            throw new NotImplementedException();
        }

        public PeliculaRepoDto Buscar(int id)
        {
            try
            {
                return _context.PeliculaRepoDto.Where(x => x.Id == id).Include(x => x.PeliculaGenero).ThenInclude(x => x.Genero).FirstOrDefault();
               
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<PeliculaRepoDto> listar()
        {
            try
            {
                return _context.PeliculaRepoDto.Include(x => x.PeliculaGenero).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
