using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOVIE.PREFERENCES.REPO.Interfaces
{
    public interface IRepositorio<I,M>
    {
        List<M> listar();

        M Buscar(I id);
    }
}
