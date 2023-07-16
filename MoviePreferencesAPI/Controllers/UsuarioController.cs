


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MOVIE.PREFERENCES.REPO.Interfaces;
using MOVIE.PREFERENCES.REPO.MODELS;

namespace MoviePreferencesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IRepositorio<Int32, UsuarioRepoDto> usuarioRepositorio;

        private readonly ILogger<UsuarioController> _logger;

        public UsuarioController(ILogger<UsuarioController> logger,
            IRepositorio<Int32, UsuarioRepoDto> usuarioRepositorio)
        {
            _logger = logger;
            this.usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet(Name = "GetUsuarios")]
        public List<UsuarioRepoDto> GetAll()
        {
            return usuarioRepositorio.listar();
        }

        [HttpGet("{id}")]
        public UsuarioRepoDto GetById(int id)
        {
            return usuarioRepositorio.Buscar(id);
        }

        [HttpPost]
        public ActionResult<UsuarioRepoDto> Create(UsuarioRepoDto usuario)
        {
            //usuarioRepositorio.Add(usuario);
            ///_context.SaveChanges();*/
            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);

        }
    }
}