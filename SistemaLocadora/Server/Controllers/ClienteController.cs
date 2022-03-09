using Microsoft.AspNetCore.Mvc;
using SistemaLocadora.Domain.Interfaces.Repositories;
using SistemaLocadora.Service.Services.Interfaces;
using SistemaLocadora.Shared.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaLocadora.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }
        // GET: api/<ClienteController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAll());
        }

        // GET api/<ClienteController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetById(id));
        }

        // POST api/<ClienteController>
        [HttpPost]
        public IActionResult Post([FromBody] ClienteDTO clienteDTO)
        {
            try
            {
                _service.Add(clienteDTO);
                return Ok(clienteDTO);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ClienteController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ClienteDTO clienteDTO)
        {
            try
            {
                clienteDTO = await _service.Update(id, clienteDTO);
                return Ok(clienteDTO);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ClienteController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                ClienteDTO clienteDTO = await _service.Delete(id);
                return Ok(clienteDTO);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
