using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using ProyectoResenaApp.Pages;
using ProyectoResenaApp.Servicios;

namespace ProyectoResenaApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
                .UseMauiCommunityToolkit();

            builder.Services.AddSingleton<IJuegoApi, JuegoApiService>();
            builder.Services.AddTransient<JuegosApiListados>();
            builder.Services.AddTransient<AllGames>();
            builder.Services.AddTransient<GamesDetails>();

            //builder.Services.AddHttpClient("apiCategoria", HttpClient => HttpClient.BaseAddress = new Uri("https://localhost:7118/api/Categoria"));
            //builder.Services.AddHttpClient("apiJuego", HttpClient => HttpClient.BaseAddress = new Uri("https://localhost:7118/api/Juego"));
            //builder.Services.AddHttpClient("apiResena", HttpClient => HttpClient.BaseAddress = new Uri("https://localhost:7118/api/Resena"));
#if DEBU
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
