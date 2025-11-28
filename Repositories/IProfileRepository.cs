using Security.Models;

namespace Security.Repositories
{
    public interface IProfileRepository
    {
        Task<UserProfile?> GetByIdAsync(Guid id);
        Task AddAsync(UserProfile profile);
        Task UpdateAsync(UserProfile profile);
        Task DeleteAsync(UserProfile profile);
    }
}
