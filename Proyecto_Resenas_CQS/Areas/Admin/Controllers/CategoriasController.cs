using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using ProyectoResena.AccesoDatos.Data.Repositorio.IRepositorio;
using ProyectoResenas.Models;

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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Categoria categoria = new Categoria();
            categoria = _contenedorTrabajo.CategoriaRep.Get(id);
            if(categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categoria categoria)
        {

            if (ModelState.IsValid)
            {
                //Logica para actualizar en base de datos
                
                _contenedorTrabajo.CategoriaRep.Update(categoria);
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

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.CategoriaRep.Get(id);
            if(objFromDb == null)
            {
                return Json(new {success = false, message = "Error borrando categoria"});
            }

            _contenedorTrabajo.CategoriaRep.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Borrado correctamente" });
        }

        #endregion
    }
}
