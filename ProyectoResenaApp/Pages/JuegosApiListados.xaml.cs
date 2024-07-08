using ProyectoResenaApp.Servicios;
using ProyectoResenaApp.ModelsUpdate;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace ProyectoResenaApp.Pages
{
    public partial class JuegosApiListados : ContentPage
    {
        private readonly IJuegoApi _juegoApi;

        public JuegosApiListados(IJuegoApi juegoApi, string categoria = null)
        {
            InitializeComponent();
            _juegoApi = juegoApi;
            BindingContext = this;

            if (!string.IsNullOrEmpty(categoria))
            {
                CargarJuegosPorCategoria(categoria);
            }
        }

        private async void CargarJuegosPorCategoria(string categoria)
        {
            Loading.IsVisible = true;

            var data = await _juegoApi.ObtenerJuegosPorCategoria(categoria);
            listJuegos.ItemsSource = data;

            Loading.IsVisible = false;
        }

        private async void ConsultaBTN_Clicked(object sender, EventArgs e)
        {
            Loading.IsVisible = true;

            var data = await _juegoApi.ObtenerJuegos();
            listJuegos.ItemsSource = data;

            Loading.IsVisible = false;
        }

        private void RegresarBTN_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(AllGames));
        }
    }
}
