using Microsoft.AspNetCore.Mvc;
using SistemaLocadora.Domain.Interfaces.Repositories;
using SistemaLocadora.Service.Services.Interfaces;
using SistemaLocadora.Shared.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaLocadora.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmeController : ControllerBase
    {
        private readonly IFilmeService _service;

        public FilmeController(IFilmeService service)
        {
            _service = service;
        }
        // GET: api/<FilmeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAll());
        }

        // GET api/<FilmeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetById(id));
        }

        // POST api/<FilmeController>
        [HttpPost]
        public IActionResult Post([FromBody] FilmeDTO filmeDTO)
        {
            try
            {
                _service.Add(filmeDTO);
                return Ok(filmeDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<FilmeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FilmeDTO filmeDTO)
        {
            try
            {
                filmeDTO = await _service.Update(id, filmeDTO);
                return Ok(filmeDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<FilmeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                FilmeDTO filmeDTO = new FilmeDTO();
                filmeDTO = await _service.Delete(id);

                return Ok(filmeDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
