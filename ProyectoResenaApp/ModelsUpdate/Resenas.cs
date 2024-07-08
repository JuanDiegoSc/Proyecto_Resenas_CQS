using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoResenaApp.ModelsUpdate
{
    public class Resenas
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("puntuacion")]
        public int puntuacion { get; set; }

        [JsonProperty("comentario")]
        public string comentario { get; set; }

        [JsonProperty("fechaResena")]
        public string fechaResena { get; set; }

        [JsonProperty("juegoId")]
        public int juegoId { get; set; }

        [JsonProperty("juego")]
        public object juego { get; set; }
    }
}
