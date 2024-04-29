using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoResenas.Models
{
    public class Resena
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La puntuación es requerida")]
        [Range(1, 5, ErrorMessage = "La puntuación debe estar entre 1 y 5")]
        public int Puntuacion { get; set; }

        [Required(ErrorMessage = "El comentario es requerido")]
        public string? Comentario { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Imagen")]
        public string? FechaResena { get; set; }

        [Required(ErrorMessage = "El juego es obligatorio")]
        public int JuegoId { get; set; }

        [ForeignKey("JuegoId")]
        public Juego? Juego { get; set; }
    }
}
