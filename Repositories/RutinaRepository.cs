using Microsoft.EntityFrameworkCore;
using Security.Data;
using Security.Entities;
using Security.Repositories;

namespace Secuity.Repositories
{
    public class RutinaRepository : IRutinaRepository
    {
        private readonly AppDbContext _ctx;

        public RutinaRepository(AppDbContext context)
        {
            _ctx = context;
        }

        public async Task<Rutina> CreateAsync(Rutina rutina)
        {
            _ctx.Rutinas.Add(rutina);
            await _ctx.SaveChangesAsync();
            return rutina;
        }

        public async Task<Rutina?> GetByIdAsync(int id)
        {
            return await _ctx.Rutinas
                .Include(r => r.Ejercicios)
                .Include(r => r.Usuarios)
                .Include(r => r.Creador)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<Rutina>> GetAllAsync()
        {
            return await _ctx.Rutinas
                .Include(r => r.Ejercicios)
                .Include(r => r.Creador)
                .ToListAsync();
        }

        public async Task UpdateAsync(Rutina rutina)
        {
            _ctx.Rutinas.Update(rutina);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(Rutina rutina)
        {
            _ctx.Rutinas.Remove(rutina);
            await _ctx.SaveChangesAsync();
        }
    }
}
