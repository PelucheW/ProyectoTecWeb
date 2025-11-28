using System.ComponentModel.DataAnnotations;

namespace Security.Models.DTOS
{
    public record RegisterDto
    {
        [Required]
        public required string Username { get; init; } // User.Username

        // Este lo dejo opcional, se puede mandar o no
        public string? Nombre { get; init; } // User.Nombre

        [Required]
        [EmailAddress]
        public required string Email { get; init; } // User.Email

        [Required]
        public required string Password { get; init; } // User.PasswordHash

        // Rol en la app: "Cliente" o "Trainer"
        [Required]
        public string Role { get; init; } = "Cliente";
    }
}
