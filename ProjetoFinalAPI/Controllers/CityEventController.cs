using ProjetoFinalAPI.Service.Dto;
using ProjetoFinalAPI.Service.Entity;
using ProjetoFinalAPI.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ProjetoFinalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class CityEventController : ControllerBase
    {
        private ICityEventService _cityEventService { get; set; }

        public CityEventController(ICityEventService cityEventService)
        {
            _cityEventService = cityEventService;
        }

        [HttpGet("Preço+Data")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<CityEventDto> ConsultarEventoPD(decimal preço, DateTime data)
        {
            return Ok(_cityEventService.ConsultarEventoPD(preço, data));
        }

        [HttpGet("Local+Data")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<CityEventDto> ConsultarEventoLD(string local, DateTime data)
        {
            return Ok(_cityEventService.ConsultarEventoLD(local, data));
        }

        [HttpGet("Titulo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<CityEventDto> ConsultarEventoT(string titulo)
        {
            return Ok(_cityEventService.ConsultarEventoT(titulo));
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CityEventDto>> InserirEvento(CityEventDto entity)
        {
            if (!await _cityEventService.AdicionarEvento(entity))
            {
                return BadRequest();
            }
            return Ok(entity);
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CityEventDto>> EditarEvento(CityEventDto entity, int id)
        {
            if (!await _cityEventService.EditarEvento(entity, id))
            {
                return BadRequest();
            }
            return Ok(entity);
        }
        [Authorize(Roles = "admin")]
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeletarEvento([FromQuery] int id)
        {

            if (!await _cityEventService.DeletarEvento(id))
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}