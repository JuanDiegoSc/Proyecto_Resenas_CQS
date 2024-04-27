using Microsoft.AspNetCore.Mvc;
using ProyectoResena.AccesoDatos.Data.Repositorio.IRepositorio;

namespace Proyecto_Resenas_CQS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class JuegosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public JuegosController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region Llamadas a la "API"

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.JuegoRep.GetAll() });
        }
        #endregion
    }
}
