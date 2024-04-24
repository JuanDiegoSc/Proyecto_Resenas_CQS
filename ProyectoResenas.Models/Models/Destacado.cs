using System.ComponentModel.DataAnnotations;

namespace Proyecto_Resenas_CQS.Models
{
    public class Destacado
    {
        [Key]
        public int DestacadoId { get; set; }
        [Required]
        public string? Descripcion { get; set; }

        [Required]
        public DateTime FechaAgregado { get; set; }


        public int JuegoId { get; set; }

        public Juego? Juego { get; set; }
    }
}
