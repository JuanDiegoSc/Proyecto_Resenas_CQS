using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoResenaApp.Models
{
    public class Juego
    {
        public string? Nombre { get; set; }
        public string? Imagen { get; set; }
        public string? Desarrollador { get; set; }
        public string? Editor { get; set; }
        public string? FechaLanzamiento { get; set; }
        public string? Requerimientos { get; set; }

        public ObservableCollection<Resena>? Resenas { get; set; }
    }
}
