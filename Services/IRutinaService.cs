using System;
using Security.DTOs.Rutina;
using Security.Entities;

namespace Security.Services
{
    public interface IRutinaService
    {
        // Creador es un Guid (porque User.Id es Guid)
        Task<Rutina> CreateAsync(CreateRutinaDto dto, Guid userId);

        // Estas pueden devolver null si no se encuentra la rutina
        Task<Rutina?> UpdateAsync(int id, UpdateRutinaDto dto);
        Task<Rutina?> GetByIdAsync(int id);

        Task<List<Rutina>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
    }
}
