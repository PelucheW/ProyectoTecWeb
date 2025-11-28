using System.ComponentModel.DataAnnotations;

namespace Security.Models.DTOS
{
    public class CreateProfileDto
    {
        [Required]
        public double Edad { get; init; }
        [Required]
        public double Peso { get; init; }
        [Required]
        public double Altura { get; init; }

        [Required]
        public string Objetivo { get; init; } = string.Empty; // perder peso, ganar masa, etc.
        [Required]
        public string Nivel { get; init; } = string.Empty; // principiante, intermedio, avanzado

        public string? Especialidad { get; init; }
        public int? AniosExperiencia { get; init; }
        public string? Certificacion { get; init; }
    }
}

