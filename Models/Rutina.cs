using Security.Models;
public class Rutina
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }
    public string Objetivo { get; set; }
    public string NivelObjetivo { get; set; }

    public int? CreadorId { get; set; }
    public User Creador { get; set; }

    public List<User> Usuarios { get; set; } = new();

    public List<Ejercicio> Ejercicios { get; set; } = new();
}
