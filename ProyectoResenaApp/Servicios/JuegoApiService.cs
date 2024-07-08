using Newtonsoft.Json;
using ProyectoResenaApp.ModelsUpdate;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace ProyectoResenaApp.Servicios
{
    public class JuegoApiService : IJuegoApi
    {
        public string urlApi = "https://api.rawg.io/api/games?key=c1843dfe3a34440dbf3adf0357a610ed";

        public async Task<List<JuegoResponse>> ObtenerJuegos()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(urlApi);
            var responseBody = await response.Content.ReadAsStringAsync();
            JsonNode nodos = JsonNode.Parse(responseBody);
            JsonNode results = nodos["results"];

            var juegosData = System.Text.Json.JsonSerializer.Deserialize<List<JuegoResponse>>(results.ToString());

            foreach (var juego in juegosData)
            {
                Console.WriteLine($"Game: {juego.name}, Image URL: {juego.background_image}");
            }

            return juegosData;
        }

        public async Task<List<JuegoResponse>> ObtenerJuegosPorCategoria(string categoria)
        {
            var httpClient = new HttpClient();
            string urlApiConCategoria = $"https://api.rawg.io/api/games?key=c1843dfe3a34440dbf3adf0357a610ed&genres={categoria}";
            var response = await httpClient.GetAsync(urlApiConCategoria);
            var responseBody = await response.Content.ReadAsStringAsync();
            JsonNode nodos = JsonNode.Parse(responseBody);
            JsonNode results = nodos["results"];

            var juegosData = System.Text.Json.JsonSerializer.Deserialize<List<JuegoResponse>>(results.ToString());

            foreach (var juego in juegosData)
            {
                Console.WriteLine($"Juegos: {juego.name}, Imagen URL: {juego.background_image}");
            }

            return juegosData;
        }
    }
}

