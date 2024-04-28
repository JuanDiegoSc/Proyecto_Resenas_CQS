using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoResena.AccesoDatos.Data.Repositorio.IRepositorio;
using ProyectoResenas.Models.ViewModels;
using ProyectoResenas.Models;

namespace Proyecto_Resenas_CQS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlidersController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public SlidersController(IContenedorTrabajo contenedorTrabajo,
            IWebHostEnvironment hostingEnvironment)
        {
            _contenedorTrabajo = contenedorTrabajo;
            _hostingEnvironment = hostingEnvironment;
            
        }
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
        public IActionResult Create(Slider slider)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;
                if(archivos.Count()>0)
                {
                    //nuevo slider
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\sliders");
                    var extension = Path.GetExtension(archivos[0].FileName);
                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }
                    slider.UrlImagen = @"\imagenes\sliders\" + nombreArchivo + extension;

                    _contenedorTrabajo.SliderRep.Add(slider);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("Imagen", "Debes seleccionar una imagen");
                }
            }
            
            return View(slider);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {

            if(id != null)
            {
                var slider = _contenedorTrabajo.SliderRep.Get(id.GetValueOrDefault());
                return View(slider);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Slider slider)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;
                var sliderDesdeBD = _contenedorTrabajo.SliderRep.Get(slider.Id);

                if (archivos.Count() > 0)
                {
                    //nuevo slider
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\sliders");
                    var extension = Path.GetExtension(archivos[0].FileName);
                    var nuevaExtension = Path.GetExtension(archivos[0].FileName);
                    var rutaImg = Path.Combine(rutaPrincipal, sliderDesdeBD.UrlImagen.TrimStart('\\'));

                    if (System.IO.File.Exists(rutaImg))
                    {
                        System.IO.File.Delete(rutaImg);
                    }

                    //Nuevo archivo
                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }


                    slider.UrlImagen = @"\imagenes\sliders\" + nombreArchivo + extension;

                    _contenedorTrabajo.SliderRep.Update(slider);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //Si la imagen ya existe
                    slider.UrlImagen = sliderDesdeBD.UrlImagen;
                }

                _contenedorTrabajo.SliderRep.Update(slider);
                _contenedorTrabajo.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(slider);
        }


        #region Llamadas a la "API"

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.SliderRep.GetAll() });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var sliderFromDb = _contenedorTrabajo.SliderRep.Get(id);
            string rutaDirectorioPrincipal = _hostingEnvironment.WebRootPath;
            var rutaImg = Path.Combine(rutaDirectorioPrincipal, sliderFromDb.UrlImagen.TrimStart('\\'));
            if (System.IO.File.Exists(rutaImg))
            {
                System.IO.File.Delete(rutaImg);
            }
            if (sliderFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando slider" });
            }

            _contenedorTrabajo.SliderRep.Remove(sliderFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Slider Borrado correctamente" });
        }
        #endregion
    }
}
