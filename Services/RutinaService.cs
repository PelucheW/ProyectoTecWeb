using Security.DTOs.Rutina;
using Security.Entities;
using Security.Repositories;

namespace Security.Services
{
    public class RutinaService : IRutinaService
    {
        private readonly IRutinaRepository _repos;
        private readonly IEjercicioRepository _ejercicioRepos;

        public RutinaService(
            IRutinaRepository repos,
            IEjercicioRepository ejercicioRepos)
        {
            _repos = repos;
            _ejercicioRepos = ejercicioRepos;
        }

        public async Task<Rutina> CreateAsync(CreateRutinaDto dto, int userId)
        {
            var ejercicios = await _ejercicioRepos.GetByIdsAsync(dto.EjerciciosIds);

            var rutina = new Rutina
            {
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Objetivo = dto.Objetivo,
                NivelObjetivo = dto.NivelObjetivo,
                CreadorId = userId,
                Ejercicios = ejercicios
            };

            return await _repos.CreateAsync(rutina);
        }

        public async Task<Rutina> UpdateAsync(int id, UpdateRutinaDto dto)
        {
            var rutina = await _repos.GetByIdAsync(id);
            if (rutina == null) return null;

            rutina.Nombre = dto.Nombre;
            rutina.Descripcion = dto.Descripcion;
            rutina.Objetivo = dto.Objetivo;
            rutina.NivelObjetivo = dto.NivelObjetivo;

            rutina.Ejercicios = await _ejercicioRepos.GetByIdsAsync(dto.EjerciciosIds);

            await _repos.UpdateAsync(rutina);
            return rutina;
        }

        public async Task<List<Rutina>> GetAllAsync() => await _repos.GetAllAsync();

        public async Task<Rutina> GetByIdAsync(int id) => await _repos.GetByIdAsync(id);

        public async Task<bool> DeleteAsync(int id)
        {
            var rutina = await _repos.GetByIdAsync(id);
            if (rutina == null) return false;

            await _repos.DeleteAsync(rutina);
            return true;
        }
    }
}