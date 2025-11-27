namespace Security.Models.DTOS
{
    public class CreateEjercicioDto
    {
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string GrupoMuscular { get; set; } = string.Empty;
        public string Equipamiento { get; set; } = string.Empty;
    }
}
