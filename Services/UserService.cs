using Security.Models;
using Security.Models.DTOS;
using Security.Repositories;

namespace Security.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepo;
        private readonly IProfileRepository _profileRepo;

        public UserService(IUserRepository userRepo, IProfileRepository profileRepo)
        {
            _userRepo = userRepo;
            _profileRepo = profileRepo;
        }

        public Task<User?> GetUserByIdAsync(Guid id)
        {
            // Asumiendo que UserRepository necesita un método GetByIdAsync
            // Por ahora solo usaremos el GetByEmailAddress si no hay un GetById.
            // **Recomendación:** Agregar Task<User?> GetByIdAsync(Guid id) a IUserRepository
            return _userRepo.GetByEmailAddress(""); // Placeholder, cambiar por GetByIdAsync
        }

        // --- Gestión de Perfil (UserProfile) ---

        public async Task<ReadProfileDto?> GetProfileByIdAsync(Guid userId)
        {
            var profile = await _profileRepo.GetByIdAsync(userId);
            if (profile == null) return null;

            return new ReadProfileDto
            {
                UserId = profile.Id,
                Edad = profile.Edad,
                Peso = profile.Peso,
                Altura = profile.Altura,
                Objetivo = profile.Objetivo,
                Nivel = profile.Nivel,
                Especialidad = profile.Especialidad,
                AniosExperiencia = profile.AniosExperiencia,
                Certificacion = profile.Certificacion
            };
        }

        public async Task<ReadProfileDto?> UpdateProfileAsync(Guid userId, UpdateProfileDto dto)
        {
            var profile = await _profileRepo.GetByIdAsync(userId);
            if (profile == null) return null;

            // Aplicar solo las actualizaciones recibidas (usando la convención de DTOs opcionales)
            if (dto.Edad.HasValue) profile.Edad = dto.Edad.Value;
            if (dto.Peso.HasValue) profile.Peso = dto.Peso.Value;
            if (dto.Altura.HasValue) profile.Altura = dto.Altura.Value;
            if (dto.Objetivo is not null) profile.Objetivo = dto.Objetivo;
            if (dto.Nivel is not null) profile.Nivel = dto.Nivel;
            if (dto.Especialidad is not null) profile.Especialidad = dto.Especialidad;
            if (dto.AniosExperiencia.HasValue) profile.AniosExperiencia = dto.AniosExperiencia.Value;
            if (dto.Certificacion is not null) profile.Certificacion = dto.Certificacion;

            await _profileRepo.UpdateAsync(profile);
            return await GetProfileByIdAsync(userId); // Retorna el DTO de lectura actualizado
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            // La eliminación del User debe eliminar también el Profile
            var user = await _userRepo.GetByEmailAddress(""); // Placeholder: obtener usuario
            if (user == null) return false;

            var profile = await _profileRepo.GetByIdAsync(id);
            if (profile != null)
            {
                await _profileRepo.DeleteAsync(profile);
            }

            // await _userRepo.DeleteAsync(user); // Asumir que existe un método DeleteAsync en UserRepository
            return true;
        }
    }
}