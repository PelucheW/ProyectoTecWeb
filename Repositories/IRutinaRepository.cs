using Proyecto.Entities;

namespace Proyecto.Repositories
{
    public interface IRutinaRepository
    {
        Task<Rutina> CreateAsync(Rutina rutina);
        Task<Rutina> GetByIdAsync(int id);
        Task<List<Rutina>> GetAllAsync();
        Task UpdateAsync(Rutina rutina);
        Task DeleteAsync(Rutina rutina);
    }
}
