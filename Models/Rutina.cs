using Security.Models;

namespace Security.Entities
{
    public class Rutina
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Objetivo { get; set; } = string.Empty;
        public string NivelObjetivo { get; set; } = string.Empty;

        // FK al creador (User) – coincide con User.Id (Guid)
        public Guid? CreadorId { get; set; }

        // Navegación al creador (puede ser null si aún no se asignó)
        public User? Creador { get; set; }

        // Usuarios que usan esta rutina (N:M)
        public List<User> Usuarios { get; set; } = new();

        // Ejercicios que componen la rutina (N:M)
        public List<Ejercicio> Ejercicios { get; set; } = new();
    }
}
