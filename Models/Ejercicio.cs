namespace Security.Models
{
    public class Ejercicio
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string GrupoMuscular { get; set; } = string.Empty;   
        public string Equipamiento { get; set; } = string.Empty;    
    }
}
