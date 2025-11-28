using Security.Entities;
using System.ComponentModel.DataAnnotations;

namespace Security.Models
{
    public class User
    {
        public Guid Id { get; set; } // Usando Guid por consistencia con el código anterior

        [Required]
        public string Username { get; set; } = string.Empty; // Mapeado del diagrama

        [Required]
        public string Nombre { get; set; } = string.Empty; // Mapeado del diagrama
        public string Apellido { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = "Cliente"; // "Cliente" o "Trainer"
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow; // Nuevo campo
        public bool Activo { get; set; } = true; // Nuevo campo

        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiresAt { get; set; }
        public DateTime? RefreshTokenRevokedAt { get; set; }
        public string? CurrentJwtId { get; set; }

        // Relación 1:1 con UserProfile
        public UserProfile? Profile { get; set; }
        // Relación 1:N con Rutina
        // Un usuario puede crear muchas Rutinas. 
        // El nombre debe coincidir con el que causa el error: "RutinasCreadas"
        public ICollection<Rutina> RutinasCreadas { get; set; } = new List<Rutina>();
    }
}