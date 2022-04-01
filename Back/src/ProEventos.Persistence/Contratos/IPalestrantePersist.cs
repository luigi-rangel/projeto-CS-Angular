using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Contratos
{
    public interface IPalestrantePersist
    {
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string Nome, bool includePalestrantes);
         Task<Palestrante[]> GetAllPalestrantesAsync(bool includePalestrantes);
         Task<Palestrante> GetPalestranteByIdAsync(int PalestranteId, bool includePalestrantes);
    }
}