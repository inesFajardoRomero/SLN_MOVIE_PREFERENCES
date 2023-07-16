using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOVIE.PREFERENCES.REPO.MODELS
{
    public class UsuarioRepoDto
    {
        public int Id { get; set; }

        public string Usuario { get; set; }

        public string Contrasena { get; set; }

        public string Correo { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public List<UsuarioGeneroRepoDto> UsuarioGenero { get; set; }
    }
}
