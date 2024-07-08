using ProyectoResenaApp.Models;
using ProyectoResenaApp.ViewModels;

namespace ProyectoResenaApp.Pages;

public partial class RegistroUsuario : ContentPage
{

    Usuario _usuario;


	public RegistroUsuario()
	{

		InitializeComponent();
        //_usuario = new Usuario();
        //this.BindingContext = _usuario;
        BindingContext = new userViewModel();
	}


    //private async void CrearCuentabtn(object sender, EventArgs e)
    //{
    //    if(string.IsNullOrWhiteSpace(_usuario.Name)&&
    //       string.IsNullOrWhiteSpace(_usuario.Email)&&
    //       string.IsNullOrWhiteSpace(_usuario.contra))
    //    {
    //        await DisplayAlert("Alerta", "LLena todas las celdas", "Ok");
    //        return;
    //    }

    //    var registro = await App.BaseDeDatos.UsuarioDataTable.GuardarUsuario(_usuario);
    //    if(registro > 0)
    //    {
    //        await Shell.Current.GoToAsync(nameof(AllGames));
    //    }

    //}

    private void RegresarBtn(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(LoginUsuario));
    }
}