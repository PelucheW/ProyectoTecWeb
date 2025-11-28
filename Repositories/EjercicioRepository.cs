using Microsoft.EntityFrameworkCore;
using Security.Data;
using Security.Models;

namespace Security.Repositories
{
    public class EjercicioRepository : IEjercicioRepository
    {
        private readonly AppDbContext _ctx;

        public EjercicioRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public Task<List<Ejercicio>> GetAllAsync()
        {
            return _ctx.Ejercicios.ToListAsync();
        }

        public Task<Ejercicio?> GetByIdAsync(Guid id)
        {
            return _ctx.Ejercicios.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Ejercicio> CreateAsync(Ejercicio ejercicio)
        {
            _ctx.Ejercicios.Add(ejercicio);
            await _ctx.SaveChangesAsync();
            return ejercicio;
        }

        public async Task UpdateAsync(Ejercicio ejercicio)
        {
            _ctx.Ejercicios.Update(ejercicio);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(Ejercicio ejercicio)
        {
            _ctx.Ejercicios.Remove(ejercicio);
            await _ctx.SaveChangesAsync();
        }

        public Task<List<Ejercicio>> GetByIdsAsync(IEnumerable<Guid> ids)
        {
            return _ctx.Ejercicios
                .Where(e => ids.Contains(e.Id))
                .ToListAsync();
        }
    }
}
