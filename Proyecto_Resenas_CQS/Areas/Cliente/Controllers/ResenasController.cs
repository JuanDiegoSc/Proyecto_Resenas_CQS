using Microsoft.AspNetCore.Mvc;
using ProyectoResena.AccesoDatos.Data.Repositorio.IRepositorio;
using ProyectoResenas.Models;
using ProyectoResenas.Models.ViewModels;

namespace Proyecto_Resenas_CQS.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    public class ResenasController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public ResenasController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;

        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            ResenaVM resenaVM = new ResenaVM()
            {
                Resena = new ProyectoResenas.Models.Resena(),
                ListaJuegos = _contenedorTrabajo.JuegoRep.GetListaJuegos()
            };
            return View(resenaVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ResenaVM resenaVM)
        {

            if (ModelState.IsValid)
            {
                //Logica para guardar en base de datos
                 resenaVM.Resena.FechaResena = DateTime.Now.ToString();
                _contenedorTrabajo.ResenaRep.Add(resenaVM.Resena);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));

            }
            resenaVM.ListaJuegos = _contenedorTrabajo.CategoriaRep.GetListaCategorias();
            return View(resenaVM);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Resena resena = new Resena();
            resena = _contenedorTrabajo.ResenaRep.Get(id);
            if (resena == null)
            {
                return NotFound();
            }
            return View(resena);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Resena resena)
        {

            if (ModelState.IsValid)
            {
                //Logica para actualizar en base de datos

                _contenedorTrabajo.ResenaRep.Update(resena);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));

            }
            return View(resena);
        }

        #region Llamadas a la "API"

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.ResenaRep.GetAll() });
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.ResenaRep.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando Reseña" });
            }

            _contenedorTrabajo.ResenaRep.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Borrado correctamente" });
        }
        #endregion
    }
}
