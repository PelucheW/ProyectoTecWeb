using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Security.Models
{
    public class UserProfile
    {

        [Key]
        public Guid Id { get; set; }

        public double Edad { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }

        public string Objetivo { get; set; } = string.Empty;
        public string Nivel { get; set; } = "Principiante";

        public string? Especialidad { get; set; }
        public int? AniosExperiencia { get; set; }
        public string? Certificacion { get; set; }

        // Navegación 1:1
        [ForeignKey("Id")]
        public User User { get; set; } = null!;
    }
}
