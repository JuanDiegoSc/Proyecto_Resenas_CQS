using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoResenaApp.ModelsUpdate
{
    public class Categoria    
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("nombre")]
        public string nombre { get; set; }

        [JsonProperty("orden")]
        public int orden { get; set; }
        public List<object> juegos { get; set; }
    }
}
