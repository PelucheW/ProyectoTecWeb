using Security.Entities;
using System.ComponentModel.DataAnnotations;

namespace Security.Models
{
    public class User
    {
        public Guid Id { get; set; } 

        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string Nombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string Role { get; set; } = "Cliente"; // "Cliente" o "Trainer"

        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool Activo { get; set; } = true;

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiresAt { get; set; }
        public DateTime? RefreshTokenRevokedAt { get; set; }
        public string? CurrentJwtId { get; set; }

        // Relación 1:1 con UserProfile
        public UserProfile? Profile { get; set; }

        // 1:N – un usuario puede crear muchas Rutinas
        public ICollection<Rutina> RutinasCreadas { get; set; } = new List<Rutina>();
    }
}
