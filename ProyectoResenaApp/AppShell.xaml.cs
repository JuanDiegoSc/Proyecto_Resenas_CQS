using ProyectoResenaApp.Pages;

namespace ProyectoResenaApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(OnboardingPage), typeof(OnboardingPage));
            Routing.RegisterRoute(nameof(AllGames), typeof(AllGames));
            Routing.RegisterRoute(nameof(LoginUsuario), typeof(LoginUsuario));
            Routing.RegisterRoute(nameof(RegistroUsuario), typeof(RegistroUsuario));
            Routing.RegisterRoute(nameof(GamesDetails), typeof(GamesDetails));
            Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
            Routing.RegisterRoute(nameof(JuegosApiListados), typeof(JuegosApiListados));
            Routing.RegisterRoute(nameof(Favoritos), typeof(Favoritos));
        }
    }
}
