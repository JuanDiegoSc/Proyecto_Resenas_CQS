using ProyectoResenaApp.Models;
using ProyectoResenaApp.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProyectoResenaApp.ViewModels
{
    public class userViewModel : INotifyPropertyChanged
    {

        private string _nombre;
        private string _email;
        private string _password;

        public string Nombre
        {
            get => _nombre;
            set
            {
                _nombre = value;
                OnPropertyChanged(nameof(Nombre));
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand RegisterCommand { get; }
        public ICommand LoginCommand { get; }

        public userViewModel()
        {
            RegisterCommand = new Command(async () => await RegisterUser());
            LoginCommand = new Command(async () => await LoginUser());
        }

        private async Task RegisterUser()
        {
            if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Alerta", "Llena todas las celdas", "Ok");
                return;
            }

            var registro = await App.BaseDeDatos.UsuarioDataTable.GuardarUsuario(new Usuario { Name = Nombre, Email = Email, contra = Password });
            if (registro > 0)
            {
                await Shell.Current.GoToAsync(nameof(AllGames));
            }
        }

        private async Task LoginUser()
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
            {
                await Application.Current.MainPage.DisplayAlert("Alerta", "Llena todas las celdas", "Ok");
                return;
            }

            var usuario = await App.BaseDeDatos.UsuarioDataTable.ObtenerUsuario(Email, Password);
            if (usuario == null)
            {
                await Application.Current.MainPage.DisplayAlert("Alerta", "Datos inválidos", "Ok");
                return;
            }

            App.AuthService.Login(usuario);
            await Shell.Current.GoToAsync(nameof(AllGames));
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
