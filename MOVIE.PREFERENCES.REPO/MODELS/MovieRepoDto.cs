using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOVIE.PREFERENCES.REPO.MODELS
{
    public class MovieRepoDto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public string Imagen { get; set; }

        public string ImagenPoster { get; set; }

        //public string Genero { get; set; }

        public virtual ICollection<GeneroRepoDto> Genero { get; set; }
    }
}
