using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Proyecto_Resenas_CQS.Data;
using ProyectoResenas.Models;
using ProyectoResenas.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoResena.AccesoDatos.Data.Inicializador
{
    public class InicializadorBD : IInicializadorBD
    {

        private readonly ApplicationDbContext _bd;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public InicializadorBD(ApplicationDbContext bd, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _bd = bd;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public void Inicializar()
        {
            try
            {
                if(_bd.Database.GetPendingMigrations().Count()> 0)
                {
                    _bd.Database.Migrate();
                }
            }
            catch (Exception)
            {
            }
            if (_bd.Roles.Any(ro => ro.Name == CNT.Administrador)) return;

            //Creación de roles
            _roleManager.CreateAsync(new IdentityRole(CNT.Administrador)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(CNT.Registrado)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(CNT.Cliente)).GetAwaiter().GetResult();


            //Usuario inicial
            _userManager.CreateAsync(new AppUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                Nombre = "Admin",
                Direccion = "Null",
                Ciudad = "Null",
                Pais = "Null",
            }, "Admin123*").GetAwaiter().GetResult();

            AppUser usuario = _bd.AppUser.
                Where(us => us.Email == "admin@gmail.com").FirstOrDefault();
            _userManager.AddToRoleAsync(usuario, CNT.Administrador).GetAwaiter().GetResult();
        }
    }
}
