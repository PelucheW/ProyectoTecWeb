using Microsoft.EntityFrameworkCore;
using Proyecto.Data;
using Proyecto.Entities;

namespace Proyecto.Repositories
{
    public class RutinaRepository : IRutinaRepository
    {
        private readonly AppDbContext _context;

        public RutinaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Rutina> CreateAsync(Rutina rutina)
        {
            _context.Rutinas.Add(rutina);
            await _context.SaveChangesAsync();
            return rutina;
        }

        public async Task<Rutina> GetByIdAsync(int id)
        {
            return await _context.Rutinas
                .Include(r => r.Ejercicios)
                .Include(r => r.Usuarios)
                .Include(r => r.Creador)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<List<Rutina>> GetAllAsync()
        {
            return await _context.Rutinas
                .Include(r => r.Ejercicios)
                .Include(r => r.Creador)
                .ToListAsync();
        }

        public async Task UpdateAsync(Rutina rutina)
        {
            _context.Rutinas.Update(rutina);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Rutina rutina)
        {
            _context.Rutinas.Remove(rutina);
            await _context.SaveChangesAsync();
        }
    }
}
