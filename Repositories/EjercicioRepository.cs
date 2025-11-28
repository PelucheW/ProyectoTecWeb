using Microsoft.EntityFrameworkCore;
using Security.Data;
using Security.Models;
using System.Linq;

namespace Security.Repositories
{
    public class EjercicioRepository : IEjercicioRepository
    {
        private readonly AppDbContext _context;

        public EjercicioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ejercicio>> GetAllAsync()
        {
            return await _context.Ejercicios.ToListAsync();
        }

        public async Task<Ejercicio?> GetByIdAsync(int id)
        {
            return await _context.Ejercicios.FindAsync(id);
        }

        public async Task<Ejercicio> CreateAsync(Ejercicio ejercicio)
        {
            _context.Ejercicios.Add(ejercicio);
            await _context.SaveChangesAsync();
            return ejercicio;
        }

        public async Task<bool> UpdateAsync(Ejercicio ejercicio)
        {
            _context.Ejercicios.Update(ejercicio);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Ejercicios.FindAsync(id);
            if (entity == null) return false;

            _context.Ejercicios.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<List<Ejercicio>> GetByIdsAsync(List<Guid> ids)
        {
            return await _context.Ejercicios
                                 .Where(e => ids.Contains(e.Id))
                                 .ToListAsync();
        }
    }
    
    }
