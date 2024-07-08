namespace ProyectoResenaApp.Pages;

public partial class EditUsuario : ContentPage
{
	public EditUsuario()
	{
		InitializeComponent();
        if (App.AuthService.IsLoggedIn)
        {
            var user = App.AuthService.CurrentUser;
        }
        Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
    }

    private async void GuardarBtn(object sender, EventArgs e)
    {
    }

    private void CancelarBtn(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(ProfilePage));
    }
}