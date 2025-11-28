using Microsoft.EntityFrameworkCore;
using Security.Entities;
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

        public DbSet<Ejercicio> Ejercicios => Set<Ejercicio>();
        public DbSet<UserProfile> Profiles => Set<UserProfile>();
        public DbSet<Rutina> Rutinas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Ejercicio>();
            modelBuilder.Entity<User>().
                HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<UserProfile>(p => p.Id); ;

            modelBuilder.Entity<Rutina>()
                .HasMany(r => r.Ejercicios)
                .WithMany(e => e.Rutinas);

            modelBuilder.Entity<Rutina>()
                .HasOne(r => r.Creador)
                .WithMany(u => u.RutinasCreadas)
                .HasForeignKey(r => r.CreadorId);
    
        }
    }
}
