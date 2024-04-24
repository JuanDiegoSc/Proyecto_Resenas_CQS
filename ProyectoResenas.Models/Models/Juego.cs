using System.ComponentModel.DataAnnotations;

namespace Proyecto_Resenas_CQS.Models
{
    public class Juego
    {
        [Key]
        public int JuegoId { get; set; }

        public List<Destacado>? Destacados { get; set; }
    }
}
