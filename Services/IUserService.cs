using Security.Models;
using Security.Models.DTOS;

namespace Security.Services
{
    public interface IUserService
    {
        // CRUD de la cuenta base
        Task<User?> GetUserByIdAsync(Guid id);
        Task<bool> DeleteUserAsync(Guid id);

        // Gestión del Perfil (UserProfile)
        Task<ReadProfileDto?> GetProfileByIdAsync(Guid userId);
        Task<ReadProfileDto?> UpdateProfileAsync(Guid userId, UpdateProfileDto dto);
    }
}