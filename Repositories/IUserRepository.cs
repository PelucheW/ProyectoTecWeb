using Security.Models;

namespace Security.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAddress(string email);
        Task<User?> GetByRefreshToken(string refreshToken);
        Task<User?> GetByIdAsync(Guid id);          // 👈 AÑADIDO
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);                // 👈 AÑADIDO
    }
}
