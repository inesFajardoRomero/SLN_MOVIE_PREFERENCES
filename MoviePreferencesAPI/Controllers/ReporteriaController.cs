using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOVIE.PREFERENCES.REPO.MODELS;
using MOVIEPREFERENCES.PDF.Interfaces;

namespace MoviePreferencesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReporteriaController : ControllerBase
    {
        private readonly IPdfService pdfService;

        public ReporteriaController(IPdfService pdfService) 
        {
            this.pdfService = pdfService;
        }


        [HttpGet]
        public IActionResult GenerarReporte()
        {
            return Ok(new { archivo = this.pdfService.GenerarReporte()});
        }
    }
}
