namespace Security.Models.DTOS
{
    public class UpdateProfileDto
    {
        public double? Edad { get; init; }
        public double? Peso { get; init; }
        public double? Altura { get; init; }
        public string? Objetivo { get; init; }
        public string? Nivel { get; init; }
        public string? Especialidad { get; init; }
        public int? AniosExperiencia { get; init; }
        public string? Certificacion { get; init; }
    }
}
