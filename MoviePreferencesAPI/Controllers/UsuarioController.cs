


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MOVIE.PREFERENCES.REPO.Interfaces;
using MOVIE.PREFERENCES.REPO.MODELS;
using MoviePreferencesAPI.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MoviePreferencesAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IRepositorio<Int32, UsuarioRepoDto> usuarioRepositorio;

        private readonly ILogger<UsuarioController> _logger;
        private readonly IConfiguration _configuration;

        public UsuarioController(ILogger<UsuarioController> logger,
            IRepositorio<Int32, UsuarioRepoDto> usuarioRepositorio,
            IConfiguration configuration)
        {
            _logger = logger;
            this.usuarioRepositorio = usuarioRepositorio;
            _configuration = configuration;
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

        [HttpPost("registrar")]
        public ActionResult<UsuarioRepoDto> Create(UsuarioRepoDto usuario)
        {
            usuarioRepositorio.Add(usuario);
            ///_context.SaveChanges();*/
            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);

        }

        [HttpPost("login")]
        public ActionResult<RespuestaLogin> Login(CredencialesDto credenciales)
        {
            var usuario = usuarioRepositorio.listar().Find(x => x.Usuario == credenciales.usuario && x.Contrasena == credenciales.contrasena);

            if(usuario != null)
            {
                return ConstruirToken(credenciales, usuario.Rol, usuario.Id);
            }
            else
            {
                return BadRequest("Login Incorrecto");
            }


        }

        private RespuestaLogin ConstruirToken(CredencialesDto credenciales, string rol, int id)
        {

            var claims = new List<Claim>()
            {
                new Claim("usuario",credenciales.usuario),
                new Claim("rol", rol ?? ""),
                new Claim("id", id.ToString()),
            };

            var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["llavejwt"]));
            var cred = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(issuer: null, audience : null, claims :  claims, expires : null, signingCredentials: cred);

            return new RespuestaLogin { token = new JwtSecurityTokenHandler().WriteToken(token) };
        }
    }
}