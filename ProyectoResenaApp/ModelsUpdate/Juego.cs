using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ProyectoResenaApp.Models;


namespace ProyectoResenaApp.ModelsUpdate
{
    public class Juego
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty ("nombre")]
        public string nombre { get; set; }

        [JsonProperty ("descripcion")]
        public string descripcion { get; set; }

        [JsonProperty ("fechaCreacion")]
        public string fechaCreacion { get; set; }

        [JsonProperty("urlImagen")]
        public string urlImagen { get; set; }

        public string FullImageUrl => AppSettings.ApiUrl + urlImagen;

        [JsonProperty("categoriaId")]
        public int categoriaId { get; set; }

        [JsonProperty("categoria")]
        public object categoria { get; set; }


        public ObservableCollection<Resena>? Resenas { get; set; }
    }
}
