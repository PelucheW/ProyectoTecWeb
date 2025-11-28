using Security.Models;
using Security.Models.DTOS;

namespace Security.Services
{
    public interface IEjercicioService
    {
        Task<IEnumerable<Ejercicio>> GetAllAsync();
        Task<Ejercicio?> GetByIdAsync(int id);
        Task<Ejercicio?> CreateAsync(CreateEjercicioDto dto);
        Task<bool> UpdateAsync(int id, UpdateEjercicioDto dto);
        Task<bool> DeleteAsync(int id);
    }
}

