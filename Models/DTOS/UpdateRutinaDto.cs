namespace Security.Models.DTOS
{
    public class UpdateRutinaDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Objetivo { get; set; } = string.Empty;
        public string NivelObjetivo { get; set; } = string.Empty;

        public List<Guid> EjerciciosIds { get; set; } = new();
    }
}
