using Microsoft.EntityFrameworkCore;
using Security.Models;
using System.Xml.Linq;

namespace Security.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users => Set<User>();
        public DbSet<Book> Books => Set<Book>();
        public DbSet<UserProfile> Profiles => Set<UserProfile>();
        public DbSet<Hospital> Hospitals => Set<Hospital>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().
                HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<UserProfile>(p => p.Id); ;
            modelBuilder.Entity<Hospital>();
            modelBuilder.Entity<Book>();
        }
    }
}
