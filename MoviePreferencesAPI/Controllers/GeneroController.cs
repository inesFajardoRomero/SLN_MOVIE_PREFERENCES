
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MOVIE.PREFERENCES.REPO.Interfaces;
using MOVIE.PREFERENCES.REPO.MODELS;

namespace MoviePreferencesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GeneroController : ControllerBase
    {
        private readonly IRepositorio<Int32, GeneroRepoDto> generoRepositorio;

        private readonly ILogger<GeneroController> _logger;

        public GeneroController(ILogger<GeneroController> logger,
            IRepositorio<Int32, GeneroRepoDto> generoRepositorio)
        {
            _logger = logger;
            this.generoRepositorio = generoRepositorio;
        }

        [HttpGet(Name = "GetGeneros")]
        public List<GeneroRepoDto> GetAll()
        {
            return generoRepositorio.listar();
        }

        [HttpGet("{id}")]
        public GeneroRepoDto GetById(int id)
        {
            return generoRepositorio.Buscar(id);
        }

    }
}