using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoResenas.Models
{
    public class Categoria
    {

        [Key]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "Ingrese un nombre para la categoria")]
        [Display(Name = "Nombre de Catageoría")] //Muestra el texto en el campo del formulario 
        public string? Nombre { get; set; }

        [Display(Name = "Orden de visualización")]
        [Range(1, 100, ErrorMessage = "El valor debe estar entre 1 y 100")]
        public int? Orden { get; set; }
    }
}
