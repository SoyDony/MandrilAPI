using System.ComponentModel.DataAnnotations;

namespace MandrilAPI.Models
{
    public class MandrilInsert // Clase que representa un mandril para inserción
    {
        [Required]
        [MaxLength(50)]
        public string nombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string apellido { get; set; } = string.Empty;

    }
}