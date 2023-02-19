using ProjetoFinalAPI.Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoFinalAPI.Service.Interface
{
    public interface ICityEventRepository
    {
        Task<bool> AdicionarEvento(CityEventEntity evento);

        Task<bool> EditarEvento(CityEventEntity evento, int id);

        Task<bool> DeletarEvento(int id);

        Task<List<CityEventEntity>> ConsultarEventoT(string titulo);

        Task<IEnumerable<CityEventEntity>> ConsultarEventoLD(string local, DateTime data);

        Task<List<CityEventEntity>> ConsultarEventoPD(decimal preço, DateTime data);
    }
}
