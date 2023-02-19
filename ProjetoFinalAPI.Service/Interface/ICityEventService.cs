using ProjetoFinalAPI.Service.Dto;
using ProjetoFinalAPI.Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalAPI.Service.Interface
{
    public interface ICityEventService
    {
        Task<bool> AdicionarEvento(CityEventDto evento);
        Task<IEnumerable<CityEventDto>> ConsultarEventoLD(string local, DateTime data);
        Task<IEnumerable<CityEventDto>> ConsultarEventoPD(decimal preço, DateTime data);
        Task<IEnumerable<CityEventDto>> ConsultarEventoT(string titulo);
        Task<bool> EditarEvento(CityEventDto evento,int id);
        Task<bool> DeletarEvento(int id);
    }
}
