using ProyectoResenaApp.Pages;

namespace ProyectoResenaApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Comprobar si se muestra la pantalla de incorporación
            if (Preferences.Default.ContainsKey(UIConstants.OnboardingShown))
                await Shell.Current.GoToAsync($"//{nameof(AllGames)}");
            else
                await Shell.Current.GoToAsync($"//{nameof(OnboardingPage)}");
        }
    }
}

