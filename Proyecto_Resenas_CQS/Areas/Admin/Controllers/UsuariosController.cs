using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoResena.AccesoDatos.Data.Repositorio.IRepositorio;
using System.Security.Claims;

namespace Proyecto_Resenas_CQS.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrador")]
    [Area("Admin")]
    public class UsuariosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public UsuariosController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }
        [HttpGet]
        public IActionResult Index()
        { 
            //Opcion1: Obtener todos los usuarios

            //return View(_contenedorTrabajo.UsuarioRep.GetAll());

            //Opcion 2: Obtener los usuarios a excepcion del logeado

            var claimsIdentity = (ClaimsIdentity)this.User.Identity; //Usuario actual
            var usuarioActual = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            return View(_contenedorTrabajo.UsuarioRep.GetAll(u => u.Id != usuarioActual.Value));
        }

        [HttpGet]

        public IActionResult Bloquear(string id) {
            if(id == null)
            {
                return NotFound();
            }
            _contenedorTrabajo.UsuarioRep.BloquearUsuario(id);
            return RedirectToAction(nameof(Index));              
        }

        [HttpGet]
        public IActionResult Desbloquear(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _contenedorTrabajo.UsuarioRep.DesbloquearUsuario(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
