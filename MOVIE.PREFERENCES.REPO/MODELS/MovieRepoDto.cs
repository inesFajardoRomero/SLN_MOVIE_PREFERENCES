using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOVIE.PREFERENCES.REPO.MODELS
{
    public sealed class MovieRepoDto
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Imagen { get; set; }

        public string ImagenPoster { get; set; }

        public string Genero { get; set; }
    }
}
