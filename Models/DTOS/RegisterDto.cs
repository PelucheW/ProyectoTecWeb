using System.ComponentModel.DataAnnotations;

namespace Security.Models.DTOS
{
    public record RegisterDto
    {
        [Required]
        public required string Username { get; init; } 


        public string? Nombre { get; init; } 

        [Required]
        [EmailAddress]
        public required string Email { get; init; } 
        [Required]
        public required string Password { get; init; } 

        [Required]
        public string Role { get; init; } = "Cliente";
    }
}
