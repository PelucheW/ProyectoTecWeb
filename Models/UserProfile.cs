using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Security.Models
{
    public class UserProfile
    {
        // PK / FK (PK = FK a User)
        [Key]
        public Guid Id { get; set; }

        // Campos Biométricos
        public double Edad { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }

        // Campos de Gimnasio
        public string Objetivo { get; set; } = string.Empty;
        public string Nivel { get; set; } = "Principiante";

        // Campos específicos de Trainer (opcionales)
        public string? Especialidad { get; set; }
        public int? AniosExperiencia { get; set; }
        public string? Certificacion { get; set; }

        // Navegación 1:1
        [ForeignKey("Id")]
        public User User { get; set; } = null!;
    }
}
