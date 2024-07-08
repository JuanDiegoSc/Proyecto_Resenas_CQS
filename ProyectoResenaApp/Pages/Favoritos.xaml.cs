using ProyectoResenaApp.ModelsUpdate;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using System.Windows.Input;

namespace ProyectoResenaApp.Pages
{
    [QueryProperty(nameof(GameName), "name")]
    [QueryProperty(nameof(GameImage), "image")]
    public partial class Favoritos : ContentPage
    {
        public ObservableCollection<JuegoResponse> FavoritosList { get; set; }

        public string GameName { get; set; }
        public string GameImage { get; set; }

        public Favoritos()
        {
            InitializeComponent();
            FavoritosList = new ObservableCollection<JuegoResponse>();
            listFavoritos.ItemsSource = FavoritosList;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!string.IsNullOrEmpty(GameName) && !string.IsNullOrEmpty(GameImage))
            {
                var juegoResponse = new JuegoResponse
                {
                    name = GameName,
                    background_image = GameImage
                };
                FavoritosList.Add(juegoResponse);
            }
        }

        private void RegresarBTN_Clicked(object sender, EventArgs e)
        {
            Shell.Current.GoToAsync(nameof(AllGames));
        }
    }
}
