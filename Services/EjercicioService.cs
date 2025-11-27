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

        public Task<IEnumerable<Ejercicio>> GetAllAsync() => _repo.GetAllAsync();

        public Task<Ejercicio?> GetByIdAsync(int id) => _repo.GetByIdAsync(id);

        public async Task<Ejercicio?> CreateAsync(CreateEjercicioDto dto)
        {
            var entity = new Ejercicio
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                GrupoMuscular = dto.GrupoMuscular,
                Equipamiento = dto.Equipamiento
            };

            return await _repo.CreateAsync(entity);


        }

        public async Task<bool> UpdateAsync(int id, UpdateEjercicioDto dto)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) return false;

            existing.Nombre = dto.Nombre;
            existing.Descripcion = dto.Descripcion;
            existing.GrupoMuscular = dto.GrupoMuscular;
            existing.Equipamiento = dto.Equipamiento;

            return await _repo.UpdateAsync(existing);
        }

        public Task<bool> DeleteAsync(int id) => _repo.DeleteAsync(id);
    }
}

