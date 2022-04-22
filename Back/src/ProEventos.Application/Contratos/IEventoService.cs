using System.Threading.Tasks;
using ProEventos.Application.DTOs;
using ProEventos.Domain;

namespace ProEventos.Application.Contratos
{
    public interface IEventoService
    {
         Task<EventoDTO> AddEventos(EventoDTO model);
         Task<EventoDTO> UpdateEvento(int eventoId, EventoDTO model);
         Task<bool> DeleteEvento(int eventoId);

         Task<EventoDTO[]> GetAllEventosByTemaAsync(string tema, bool includePalestrantes = false);
         Task<EventoDTO[]> GetAllEventosAsync(bool includePalestrantes = false);
         Task<EventoDTO> GetEventoByIdAsync(int Id, bool includePalestrantes = false);
    }
}