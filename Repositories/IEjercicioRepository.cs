using Security.Models;

namespace Security.Repositories
{
    public interface IEjercicioRepository
    {
        Task<List<Ejercicio>> GetAllAsync();
        Task<Ejercicio?> GetByIdAsync(Guid id);
        Task<Ejercicio> CreateAsync(Ejercicio ejercicio);
        Task UpdateAsync(Ejercicio ejercicio);
        Task DeleteAsync(Ejercicio ejercicio);
        Task<List<Ejercicio>> GetByIdsAsync(IEnumerable<Guid> ids);
    }
}
