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
    public class GeneroRepoService : IRepositorio<Int32, GeneroRepoDto>
    {
        private readonly MovieContext _context;

        public GeneroRepoService(MovieContext context) 
        { 
            this._context = context;
        }

        public GeneroRepoDto Buscar(int id)
        {
            try
            {
                return _context.GeneroRepoDto.Where(x => x.Id == id).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<GeneroRepoDto> listar()
        {
            try
            {
                return _context.GeneroRepoDto.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
