namespace Security.Models.DTOS
{
    public class ReadProfileDto
    {
        public Guid UserId { get; init; }
        public double Edad { get; init; }
        public double Peso { get; init; }
        public double Altura { get; init; }
        public string Objetivo { get; init; } = string.Empty;
        public string Nivel { get; init; } = string.Empty;
        public string? Especialidad { get; init; }
        public int? AniosExperiencia { get; init; }
        public string? Certificacion { get; init; }
    }
}
