using Security.Entities;

namespace Security.Repositories
{
    public interface IRutinaRepository
    {
        Task<Rutina> CreateAsync(Rutina rutina);
        Task<Rutina?> GetByIdAsync(int id);   // 👈 aquí el cambio
        Task<List<Rutina>> GetAllAsync();
        Task UpdateAsync(Rutina rutina);
        Task DeleteAsync(Rutina rutina);
    }
}
