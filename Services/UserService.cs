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

        // ========= MÉTODOS DE USUARIO =========

        public Task<User?> GetUserByIdAsync(Guid id)
        {
            return _userRepo.GetByIdAsync(id);
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null) return false;

            // Borrar también el perfil si existe
            var profile = await _profileRepo.GetByIdAsync(id);
            if (profile != null)
            {
                await _profileRepo.DeleteAsync(profile);
            }

            await _userRepo.DeleteAsync(user);
            return true;
        }

        // ========= MÉTODOS DE PERFIL =========

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

            // Si no existe → crear perfil vacío
            if (profile == null)
            {
                profile = new UserProfile { Id = userId };
                await _profileRepo.AddAsync(profile);
            }

            // Actualizar solo lo que viene en el DTO
            if (dto.Edad.HasValue) profile.Edad = dto.Edad.Value;
            if (dto.Peso.HasValue) profile.Peso = dto.Peso.Value;
            if (dto.Altura.HasValue) profile.Altura = dto.Altura.Value;

            if (dto.Objetivo != null) profile.Objetivo = dto.Objetivo;
            if (dto.Nivel != null) profile.Nivel = dto.Nivel;

            if (dto.Especialidad != null) profile.Especialidad = dto.Especialidad;
            if (dto.AniosExperiencia.HasValue) profile.AniosExperiencia = dto.AniosExperiencia.Value;
            if (dto.Certificacion != null) profile.Certificacion = dto.Certificacion;

            await _profileRepo.UpdateAsync(profile);

            return await GetProfileByIdAsync(userId);
        }
    }
}
