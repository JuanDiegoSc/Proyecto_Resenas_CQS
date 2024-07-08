using ProyectoResenaApp.Models;
using ProyectoResenaApp.ViewModels;
using System.Security.Cryptography.X509Certificates;

namespace ProyectoResenaApp.Pages;

public partial class LoginUsuario : ContentPage
{

    public LoginUsuario()
	{
        
		InitializeComponent();
        BindingContext =  new userViewModel();
    }

    private void CrearCuenta_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(RegistroUsuario));
    }

    //private async void EntrarBtn(object sender, EventArgs e)
    //{
    //    string email = emailTxt.Text;
    //    string contra = contraTxt.Text;

    //    if(!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(contra))
    //    {
    //        var usuario = await App.BaseDeDatos.UsuarioDataTable.ObtenerUsuario(email, contra);

    //        if(usuario == null) 
    //        {
    //            await DisplayAlert("Alerta", "Datos invalidos", "ok");
    //            return;
    //        }

    //        //App.usuario = usuario;
    //        App.AuthService.Login(usuario);
    //        await Shell.Current.GoToAsync(nameof(AllGames));
    //    }
    //}

    private void VolverBtn(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AllGames));
    }
}