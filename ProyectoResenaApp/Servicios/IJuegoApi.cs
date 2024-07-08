using ProyectoResenaApp.ModelsUpdate;

namespace ProyectoResenaApp.Servicios
{
    public interface IJuegoApi
    {
        Task<List<JuegoResponse>> ObtenerJuegos();
        Task<List<JuegoResponse>> ObtenerJuegosPorCategoria(string categoria);
    }
}
