using Microsoft.AspNetCore.Mvc;
using SistemaLocadora.Domain.Interfaces.Repositories;
using SistemaLocadora.Service.Services.Interfaces;
using SistemaLocadora.Shared.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SistemaLocadora.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocacaoController : ControllerBase
    {
        private readonly ILocacaoService _service;

        public LocacaoController(ILocacaoService service)
        {
            _service = service;
        }
        
        // GET: api/<LocacaoController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAll());
        }

        // GET api/<LocacaoController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _service.GetById(id));
        }

        // POST api/<LocacaoController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LocacaoDTO locacaoDTO)
        {
            try
            {
                await _service.Add(locacaoDTO);
                return Ok(locacaoDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<LocacaoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] LocacaoDTO locacaoDTO)
        {
            try
            {
               locacaoDTO = await _service.Update(id, locacaoDTO);

                return Ok(locacaoDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<LocacaoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                LocacaoDTO locacaoDTO = new LocacaoDTO();
                locacaoDTO = await _service.Delete(id);

                return Ok(locacaoDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
