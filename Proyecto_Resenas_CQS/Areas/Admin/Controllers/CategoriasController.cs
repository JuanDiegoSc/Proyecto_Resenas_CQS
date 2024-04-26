using Microsoft.AspNetCore.Mvc;
using ProyectoResena.AccesoDatos.Data.Repositorio.IRepositorio;
using ProyectoResenas.Models.Models;

namespace Proyecto_Resenas_CQS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriasController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public CategoriasController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        [HttpGet] //Mostar una vista: HttpGet
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create() 
        {
           return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria categoria)
        {

            if(ModelState.IsValid) {
                //Logica para guardar en base de datos
                _contenedorTrabajo.CategoriaRep.Add(categoria);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));

            }
            return View(categoria);
        }

        #region Llamadas a la "API"

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new {data = _contenedorTrabajo.CategoriaRep.GetAll()});
        }

        #endregion
    }
}
