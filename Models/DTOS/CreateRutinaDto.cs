namespace Proyecto.DTOs.Rutina
{
    public class CreateRutinaDto
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Objetivo { get; set; }
        public string NivelObjetivo { get; set; }

        public List<int> EjerciciosIds { get; set; } = new();
    }
}
