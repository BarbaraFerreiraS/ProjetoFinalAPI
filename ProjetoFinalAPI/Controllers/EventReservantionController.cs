using ProjetoFinalAPI.Service.Dto;
using ProjetoFinalAPI.Service.Entity;
using ProjetoFinalAPI.Service.Interface;
using ProjetoFinalAPI.Service.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace ProjetoFinalAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class EventReservationController : ControllerBase
    {
        private IEventReservationService _eventReservationService { get; set; }

        public EventReservationController(IEventReservationService eventReservationService)
        {
            _eventReservationService = eventReservationService;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<EventReservationDto>>> ConsultarReserva(string nome, string titulo2)
        {
            return Ok(await _eventReservationService.ConsultarReserva(nome, titulo2));
        }
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> AdicionarReserva(EventReservationDto reserva)
        {
            if (!await _eventReservationService.AdicionarReserva(reserva))
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CityEventDto>> EditarReserva(int id, int quantidade)
        {
            if (!await _eventReservationService.EditarReserva(id, quantidade))
            {
                return BadRequest();
            }
            return Ok();
        }


        [HttpDelete]
        [Authorize(Roles = "admin")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> DeletarReserva([FromQuery] int id)
        {
            if (!await _eventReservationService.DeletarReserva(id))
            {
                return BadRequest();
            }
            return NoContent();
        }
    }
}
