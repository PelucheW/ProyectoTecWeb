using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Security.Models
{
    public class UserProfile
    {
        // PK / FK (PK = FK a User)
        [Key]
        public Guid Id { get; set; } // Mismo Id que User

        // Campos Biométricos
        public double Edad { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }

        // Campos de Gimnasio
        public string Objetivo { get; set; } = string.Empty; // "perder peso", "ganar masa", etc.
        public string Nivel { get; set; } = "Principiante"; // "Principiante", "Intermedio", "Avanzado"

        // Campos específicos de Trainer (pueden ser nulos si es Cliente)
        public string? Especialidad { get; set; }
        public int? AniosExperiencia { get; set; }
        public string? Certificacion { get; set; }

        // Navegación 1:1
        [ForeignKey("Id")]
        public User User { get; set; } = null!;
    }
}