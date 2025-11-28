using Security.Models;

namespace Security.Repositories
{
    public interface IEjercicioRepository
    {
        Task<IEnumerable<Ejercicio>> GetAllAsync();
        Task<Ejercicio?> GetByIdAsync(int id);
        Task<Ejercicio> CreateAsync(Ejercicio ejercicio);
        Task<bool> UpdateAsync(Ejercicio ejercicio);
        Task<bool> DeleteAsync(int id);

        Task<List<Ejercicio>> GetByIdsAsync(List<Guid> ids);
    }
}

