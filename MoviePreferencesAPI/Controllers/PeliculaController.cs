using Microsoft.AspNetCore.Mvc;
using MOVIE.PREFERENCES.REPO.Interfaces;
using MOVIE.PREFERENCES.REPO.MODELS;

namespace MoviePreferencesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeliculaController : ControllerBase
    {
        private readonly IRepositorio<Int32, PeliculaRepoDto> pelicularepositorio;

        private readonly ILogger<PeliculaController> _logger;

        public PeliculaController(ILogger<PeliculaController> logger,
            IRepositorio<Int32, PeliculaRepoDto> pelicularepositorio)
        {
            _logger = logger;
            this.pelicularepositorio = pelicularepositorio;
        }

        [HttpGet(Name = "GetPelicula")]
        public List<PeliculaRepoDto> GetAll()
        {
            return pelicularepositorio.listar();
        }

        [HttpGet("{id}")]
        public PeliculaRepoDto GetById(int id)
        {
            return pelicularepositorio.Buscar(id);
        }
    }
}
