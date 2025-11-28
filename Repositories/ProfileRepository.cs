using Microsoft.EntityFrameworkCore;
using Security.Data;
using Security.Models;

namespace Security.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private readonly AppDbContext _ctx;
        public ProfileRepository(AppDbContext ctx) => _ctx = ctx;

        public async Task AddAsync(UserProfile profile)
        {
            await _ctx.Profiles.AddAsync(profile);
            await _ctx.SaveChangesAsync();
        }

       public Task<UserProfile?> GetByIdAsync(Guid userId) =>
            _ctx.Profiles.FirstOrDefaultAsync(p => p.Id == userId);

        public async Task UpdateAsync(UserProfile profile)
        {
            _ctx.Profiles.Update(profile);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(UserProfile profile)
        {
            _ctx.Profiles.Remove(profile);
            await _ctx.SaveChangesAsync();
        }
    }
}

