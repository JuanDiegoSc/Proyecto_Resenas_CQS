using Newtonsoft.Json;
using ProyectoResenaApp.ModelsUpdate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoResenaApp.Servicios
{
    public static class ApiService 
    {
        public static async Task<List<Categoria>> GetCategorias()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "api/Categoria");
            return JsonConvert.DeserializeObject<List<Categoria>>(response);
        }

        public static async Task<List<Juego>> GetJuegos()
        {

            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync(AppSettings.ApiUrl + "api/Juego");
            return JsonConvert.DeserializeObject<List<Juego>>(response);
        }

        public static async Task<bool> AddResena(Resenas resena)
        {
            var httpClient = new HttpClient();
            var json = JsonConvert.SerializeObject(resena);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(AppSettings.ApiUrl + "api/Resena", content);
            if(!response.IsSuccessStatusCode) return false;
            return true;
        }

        public static async Task<bool> DeleteResena(int juegoId)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.DeleteAsync(AppSettings.ApiUrl + "api/Resena" + juegoId);
            if (!response.IsSuccessStatusCode) return false;
            return true;
        }
    }
}
