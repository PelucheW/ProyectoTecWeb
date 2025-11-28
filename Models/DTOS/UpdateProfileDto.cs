namespace Security.Models.DTOS
{
    public class UpdateProfileDto
    {
        public double? Edad { get; set; }
        public double? Peso { get; set; }
        public double? Altura { get; set; }

        public string? Objetivo { get; set; }
        public string? Nivel { get; set; }

        // SOLO PARA TRAINERS
        public string? Especialidad { get; set; }
        public int? AniosExperiencia { get; set; }
        public string? Certificacion { get; set; }
    }
}
