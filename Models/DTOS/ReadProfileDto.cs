namespace Security.Models.DTOS
{
    public class ReadProfileDto
    {
        public Guid UserId { get; set; }
        public double Edad { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }

        public string Objetivo { get; set; } = string.Empty;
        public string Nivel { get; set; } = string.Empty;

        public string? Especialidad { get; set; }
        public int? AniosExperiencia { get; set; }
        public string? Certificacion { get; set; }
    }
}
