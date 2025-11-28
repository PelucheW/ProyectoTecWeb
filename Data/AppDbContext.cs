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
        public DbSet<Book> Books => Set<Book>();

        public DbSet<Ejercicio> Ejercicios => Set<Ejercicio>();
        public DbSet<UserProfile> Profiles => Set<UserProfile>();
        public DbSet<Hospital> Hospitals => Set<Hospital>();
        public DbSet<Rutina> Rutinas { get; set; }
        public DbSet<Ejercicio> Ejercicios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Ejercicio>();
            modelBuilder.Entity<User>().
                HasOne(u => u.Profile)
                .WithOne(p => p.User)
                .HasForeignKey<UserProfile>(p => p.Id); ;
            modelBuilder.Entity<Hospital>();
            modelBuilder.Entity<Book>();

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
