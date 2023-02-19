using ProjetoFinalAPI.Service.Dto;
using ProjetoFinalAPI.Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalAPI.Service.Interface
{
    public interface IEventReservationService
    {
        Task<bool> AdicionarReserva(EventReservationDto reserva);
        Task<IEnumerable<EventReservationDto>> ConsultarReserva(string nome, string titulo2);
        Task<bool> DeletarReserva(int id);
        Task<bool> EditarReserva(int id, int quantidade);
    }
}
