using Microsoft.AspNetCore.Mvc;
using SistemaLocadora.Service.Services.Interfaces.ReportServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaLocadora.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteReportController : ControllerBase
    {
        private readonly IClienteServiceReport _clienteServiceReport;

        public ClienteReportController(IClienteServiceReport clienteServiceReport)
        {
            _clienteServiceReport = clienteServiceReport;
        }
        // GET: api/<ClienteReportController>
        [HttpGet("atrasados")]
        public async Task<IActionResult> GetClienteEmAtraso()
        {
            try
            {
                return Ok(await _clienteServiceReport.ClientesEmAtraso());
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("segundoclientequemaisalugou")]
        public void GetSegundoClienteQueMaisAlugou()
        {
            _clienteServiceReport.SegundoClienteQueMaisAlugou();
        }

    }
}
