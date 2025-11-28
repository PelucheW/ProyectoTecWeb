using Security.Models;
using Security.Models.DTOS;

namespace Security.Services
{
    public interface IUserService
    {
        Task<User?> GetUserByIdAsync(Guid id);
        Task<bool> DeleteUserAsync(Guid id);

        Task<ReadProfileDto?> GetProfileByIdAsync(Guid userId);
        Task<ReadProfileDto?> UpdateProfileAsync(Guid userId, UpdateProfileDto dto);
    }
}