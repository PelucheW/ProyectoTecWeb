using Proyecto.DTOs.Rutina;
using Proyecto.Entities;

namespace Proyecto.Services
{
    public interface IRutinaService
    {
        Task<Rutina> CreateAsync(CreateRutinaDto dto, int userId);
        Task<Rutina> UpdateAsync(int id, UpdateRutinaDto dto);
        Task<Rutina> GetByIdAsync(int id);
        Task<List<Rutina>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
    }
}
