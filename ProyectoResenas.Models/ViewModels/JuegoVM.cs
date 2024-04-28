using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoResenas.Models.ViewModels
{
    public class JuegoVM
    {
        public Juego Juego { get; set; }

        public  IEnumerable<SelectListItem>? ListaCategorias { get; set; }
    }
}
