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
    public class UsuarioRepoService : IRepositorio<Int32, UsuarioRepoDto>
    {
        private readonly MovieContext _context;

        public UsuarioRepoService(MovieContext context) 
        { 
            this._context = context;
        }

        public UsuarioRepoDto Buscar(int id)
        {
            try
            {
                return _context.UsuarioRepoDto.Where(x => x.Id == id).Include(x => x.UsuarioGenero).ThenInclude(x=> x.Genero).FirstOrDefault();
               
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<UsuarioRepoDto> listar()
        {
            try
            {
                return _context.UsuarioRepoDto.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }


        public UsuarioRepoDto Add(UsuarioRepoDto usuario)
        {
            try
            {
               _context.UsuarioRepoDto.Add(usuario);
                _context.SaveChanges();
                return usuario;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
