using Microsoft.AspNetCore.Mvc;
using SistemaLocadora.Service.Services.Interfaces.ReportServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaLocadora.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeReportController : ControllerBase
    {
        private readonly IFilmeReportService _serivce;

        public FilmeReportController(IFilmeReportService serivce)
        {
            _serivce = serivce;
        }

        // GET: api/<FilmeReportController>
        [HttpGet("FilmesNuncaAlugados")]
        public IActionResult FilmesNuncaAlugados()
        {
            try
            {
                return Ok(_serivce.FilmesNuncaAlugados());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
