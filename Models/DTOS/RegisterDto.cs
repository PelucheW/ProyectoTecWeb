using System.ComponentModel.DataAnnotations;

namespace Security.Models.DTOS
{
    public record RegisterDto
    {
        [Required]
        public required string Username { get; init; } // Mapea a User.Username
        [Required]
        public required string Nombre { get; init; } // Mapea a User.Nombre

        [Required]
        [EmailAddress]
        public required string Email { get; init; } // Mapea a User.Email

        [Required]
        public required string Password { get; init; } // Mapea a User.PasswordHash

        public string Rol { get; set; } = "Cliente"; // Mapea a User.Rol ("Cliente" por defecto)

        // --- Campos de la entidad UserProfile (Detalles del Gimnasio) ---

        // Asumiendo que los datos biométricos son requeridos al registrarse
        [Required]
        public double Edad { get; init; } // Mapea a UserProfile.Edad

        [Required]
        public double Peso { get; init; } // Mapea a UserProfile.Peso
        [Required]
        public string Role { get; init; } = "Cliente"; // Mapea a User.Role ("Cliente" por defecto)

        [Required]
        public double Altura { get; init; } // Mapea a UserProfile.Altura

        [Required]
        public string Objetivo { get; init; } = string.Empty; // Mapea a UserProfile.Objetivo

        [Required]
        public string Nivel { get; init; } = "Principiante";
    }
}
