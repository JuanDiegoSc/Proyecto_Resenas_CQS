namespace ProyectoResenaApp.Pages;

public partial class ProfilePage : ContentPage
{
	public ProfilePage()
	{
		InitializeComponent();
        if (App.AuthService.IsLoggedIn)
        {
            var user = App.AuthService.CurrentUser;
            emailLabel.Text = user.Email;
            nombreLabel.Text = user.Name;
            nombreLabel1.Text = user.Name;
        }
        Routing.RegisterRoute(nameof(EditUsuario), typeof(EditUsuario));
    }

    private void CerrarBtn(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(LoginUsuario));
    }

    private void VolverBtn(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AllGames));
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(EditUsuario));
    }
}