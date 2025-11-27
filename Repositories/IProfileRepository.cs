using Security.Models;

namespace Security.Repositories
{
    public interface IProfileRepository
    {
        Task AddAsync(UserProfile profile);
        Task<UserProfile?> GetByIdAsync(Guid userId);
        Task UpdateAsync(UserProfile profile);
        Task DeleteAsync(UserProfile profile);
    }
}
