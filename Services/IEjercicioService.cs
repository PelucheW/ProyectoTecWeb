using Security.Models;
using Security.Models.DTOS;

namespace Security.Services
{
    public interface IEjercicioService
    {
        Task<List<Ejercicio>> GetAllAsync();
        Task<Ejercicio?> GetByIdAsync(Guid id);
        Task<Ejercicio> CreateAsync(CreateEjercicioDto dto);
        Task<Ejercicio?> UpdateAsync(Guid id, UpdateEjercicioDto dto);
        Task<bool> DeleteAsync(Guid id);
    }
}
