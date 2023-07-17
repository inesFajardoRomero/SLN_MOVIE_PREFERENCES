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
    public class UsuarioGeneroRepoService : IRepositorio<Int32, UsuarioGeneroRepoDto>
    {
        private readonly MovieContext _context;

        public UsuarioGeneroRepoService(MovieContext context)
        {
            this._context = context;
        }

        public UsuarioGeneroRepoDto Add(UsuarioGeneroRepoDto modelo)
        {
            throw new NotImplementedException();
        }

        public UsuarioGeneroRepoDto Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public List<UsuarioGeneroRepoDto> listar()
        {
            throw new NotImplementedException();
        }
    }
}
