using Microsoft.AspNetCore.Mvc;
using MOVIE.PREFERENCES.REPO.Interfaces;
using MOVIE.PREFERENCES.REPO.MODELS;

namespace MoviePreferencesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IRepositorio<Int32, MovieRepoDto> pelicularepositorio;

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IRepositorio<Int32, MovieRepoDto> pelicularepositorio)
        {
            _logger = logger;
            this.pelicularepositorio = pelicularepositorio;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public MovieRepoDto Get()
        {
            return pelicularepositorio.Buscar(1);
        }
    }
}