using ProyectoResenaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoResenaApp.Servicios
{
    public class AuthService: IAuthService
    {
        private Usuario? _currentUser;

        public bool IsLoggedIn => _currentUser != null;

        public Usuario? CurrentUser => _currentUser;

        public void Login(Usuario usuario)
        {
            _currentUser = usuario;
        }

        public void Logout()
        {
            _currentUser = null;
        }
    }
}
