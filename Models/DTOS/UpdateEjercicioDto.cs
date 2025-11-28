using System.ComponentModel.DataAnnotations;

namespace Security.Models.DTOS
{
    public class UpdateEjercicioDto
    {
        [Required]
        public string Nombre { get; set; } = string.Empty;

        public string Descripcion { get; set; } = string.Empty;
        public string GrupoMuscular { get; set; } = string.Empty;
        public string Equipamiento { get; set; } = string.Empty;
    }
}
