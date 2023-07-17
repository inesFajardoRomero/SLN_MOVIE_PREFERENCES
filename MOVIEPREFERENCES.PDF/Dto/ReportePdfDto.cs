using MOVIE.PREFERENCES.REPO.Interfaces;
using MOVIE.PREFERENCES.REPO.MODELS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOVIEPREFERENCES.PDF.Dto
{
    public  class ReportePdfDto
    {

        public ReportePdfDto() 
        {
            this.usuarios = new List<UsuarioRepoDto>();
            this.peliculas = new List<PeliculaRepoDto>();
            this.Generos = new List<GeneroRepoDto>();
        }

        public List<UsuarioRepoDto> usuarios { get; set; }

        public List<PeliculaRepoDto> peliculas { get; set; }

        public List<GeneroRepoDto> Generos { get; set; }
    }
}
