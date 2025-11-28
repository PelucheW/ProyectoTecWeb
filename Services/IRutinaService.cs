using System;
using Security.Models.DTOS;
using Security.Entities;

namespace Security.Services
{
    public interface IRutinaService
    {
        Task<Rutina> CreateAsync(CreateRutinaDto dto, Guid userId);

        Task<Rutina?> UpdateAsync(int id, UpdateRutinaDto dto);
        Task<Rutina?> GetByIdAsync(int id);

        Task<List<Rutina>> GetAllAsync();
        Task<bool> DeleteAsync(int id);
    }
}
