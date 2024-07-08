using ProyectoResenaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoResenaApp.Servicios
{
    public interface IAuthService
    {
        bool IsLoggedIn { get; }
        Usuario CurrentUser { get; }
        void Login(Usuario usuario);
        void Logout();
    }
}
