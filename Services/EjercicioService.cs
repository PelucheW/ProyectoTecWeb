using Security.Models;
using Security.Models.DTOS;
using Security.Repositories;

namespace Security.Services
{
    public class EjercicioService : IEjercicioService
    {
        private readonly IEjercicioRepository _repo;

        public EjercicioService(IEjercicioRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Ejercicio>> GetAllAsync()
            => _repo.GetAllAsync();

        public Task<Ejercicio?> GetByIdAsync(Guid id)
            => _repo.GetByIdAsync(id);

        public async Task<Ejercicio> CreateAsync(CreateEjercicioDto dto)
        {
            var ejercicio = new Ejercicio
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                GrupoMuscular = dto.GrupoMuscular,
                Equipamiento = dto.Equipamiento
            };

            return await _repo.CreateAsync(ejercicio);
        }

        public async Task<Ejercicio?> UpdateAsync(Guid id, UpdateEjercicioDto dto)
        {
            var ejercicio = await _repo.GetByIdAsync(id);
            if (ejercicio == null) return null;

            ejercicio.Nombre = dto.Nombre;
            ejercicio.Descripcion = dto.Descripcion;
            ejercicio.GrupoMuscular = dto.GrupoMuscular;
            ejercicio.Equipamiento = dto.Equipamiento;

            await _repo.UpdateAsync(ejercicio);
            return ejercicio;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var ejercicio = await _repo.GetByIdAsync(id);
            if (ejercicio == null) return false;

            await _repo.DeleteAsync(ejercicio);
            return true;
        }
    }
}
