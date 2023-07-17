using MOVIE.PREFERENCES.REPO.DBCONTEXT;
using MOVIE.PREFERENCES.REPO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOVIE.PREFERENCES.REPO.RepoServices
{
    public class ReporteServices : IReporteService
    {

        private readonly MovieContext _context;

        public ReporteServices(MovieContext context)
        {
            this._context = context;
        }

        public object GenerarReporte()
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
