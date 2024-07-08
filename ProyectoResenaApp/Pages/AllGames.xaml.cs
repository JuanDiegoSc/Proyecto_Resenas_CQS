using ProyectoResenaApp.Servicios;
using ProyectoResenaApp.ModelsUpdate;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace ProyectoResenaApp.Pages;

public partial class AllGames : ContentPage
{
    public ICommand SelectCategoriaCommand { get; private set; }

    public AllGames()
    {
        InitializeComponent();
        BindingContext = this;
        SelectCategoriaCommand = new Command<Categoria>(OnCategoriaSelected);
        GetCategorias();
        GetJuegos();
    }

    private async void GetJuegos()
    {
        var juegos = await ApiService.GetJuegos();
        foreach (var juego in juegos)
        {
            juego.urlImagen = Path.Combine(FileSystem.AppDataDirectory, "Resources", "Images", Path.GetFileName(juego.urlImagen));
            Console.WriteLine($"Image URL: {juego.urlImagen}");
        }
        CvJuegos.ItemsSource = juegos;
    }

    private async void GetCategorias()
    {
        var categorias = await ApiService.GetCategorias();
        CvCategorias.ItemsSource = categorias;
    }

    private async void OnCategoriaSelected(Categoria categoria)
    {
        if (categoria != null)
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "SelectedCategoria", categoria.nombre }
            };
            await Shell.Current.GoToAsync(nameof(JuegosApiListados), navigationParameter);
        }
    }

    private async void ResenasBtn(object sender, EventArgs e)
    {
        var image = sender as Image;
        var game = image.BindingContext as Juego;
        if (game != null)
        {
            var parameters = new Dictionary<string, object>
            {
                { "SelectedGame", game }
            };
            await Shell.Current.GoToAsync(nameof(GamesDetails), parameters);
        }
    }

    private async void HomeBtn(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Favoritos));
    }

    private async void ProfileBtn(object sender, EventArgs e)
    {
        if (App.AuthService.IsLoggedIn)
        {
            await Navigation.PushAsync(new ProfilePage());
        }
        else
        {
            await DisplayAlert("No autenticado", "Debe iniciar sesión para acceder al perfil", "OK");
            await Navigation.PushAsync(new LoginUsuario());
        }
    }
}
