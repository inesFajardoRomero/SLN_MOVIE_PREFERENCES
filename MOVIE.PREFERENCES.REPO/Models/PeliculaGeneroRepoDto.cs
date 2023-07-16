using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOVIE.PREFERENCES.REPO.MODELS
{
    public class PeliculaGeneroRepoDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PeliculaId {  get; set; }

        public int GeneroId { get; set; }

        public PeliculaRepoDto Pelicula { get; set; }

        public GeneroRepoDto Genero { get; set; }

    }
}
