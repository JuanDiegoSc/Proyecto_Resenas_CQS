using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectoResena.AccesoDatos.Data.Repositorio.IRepositorio;
using ProyectoResenas.Models.ViewModels;

namespace Proyecto_Resenas_CQS.Areas.Admin.Controllers
{
    [Authorize(Roles = "Administrador")]
    [Area("Admin")]
    public class JuegosController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public JuegosController(IContenedorTrabajo contenedorTrabajo,
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
            JuegoVM juegoVM = new JuegoVM()
            {
              Juego = new ProyectoResenas.Models.Juego(),
              ListaCategorias = _contenedorTrabajo.CategoriaRep.GetListaCategorias()
              
            };
            return View(juegoVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(JuegoVM juegoVM)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;
                if(juegoVM.Juego.Id ==0 && archivos.Count()>0)
                {
                    //nuevo juego 
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\juegos");
                    var extension = Path.GetExtension(archivos[0].FileName);
                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }
                    juegoVM.Juego.UrlImagen = @"\imagenes\juegos\" + nombreArchivo + extension;
                    juegoVM.Juego.FechaCreacion = DateTime.Now.ToString();

                    _contenedorTrabajo.JuegoRep.Add(juegoVM.Juego);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("Imagen", "Debes seleccionar una imagen");
                }
            }
            juegoVM.ListaCategorias = _contenedorTrabajo.CategoriaRep.GetListaCategorias();
            return View(juegoVM);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            JuegoVM juegoVM = new JuegoVM()
            {
                Juego = new ProyectoResenas.Models.Juego(),
                ListaCategorias = _contenedorTrabajo.CategoriaRep.GetListaCategorias()

            };

            if(id != null)
            {
                juegoVM.Juego = _contenedorTrabajo.JuegoRep.Get(id.GetValueOrDefault());
            }
            return View(juegoVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(JuegoVM juegoVM)
        {
            if (ModelState.IsValid)
            {
                string rutaPrincipal = _hostingEnvironment.WebRootPath;
                var archivos = HttpContext.Request.Form.Files;

                var juegoDesdeBD = _contenedorTrabajo.JuegoRep.Get(juegoVM.Juego.Id);



                if (archivos.Count() > 0)
                {
                    //nuevo imagen para juego
                    string nombreArchivo = Guid.NewGuid().ToString();
                    var subidas = Path.Combine(rutaPrincipal, @"imagenes\juegos");
                    var extension = Path.GetExtension(archivos[0].FileName);
                    var nuevaExtension = Path.GetExtension(archivos[0].FileName);

                    var rutaImagen = Path.Combine(rutaPrincipal, juegoDesdeBD.UrlImagen.TrimStart('\\'));

                    if(System.IO.File.Exists(rutaImagen))
                    {
                        System.IO.File.Delete(rutaImagen);
                    }

                    //se sube el archivo

                    using (var fileStreams = new FileStream(Path.Combine(subidas, nombreArchivo + extension), FileMode.Create))
                    {
                        archivos[0].CopyTo(fileStreams);
                    }
                    juegoVM.Juego.UrlImagen = @"\imagenes\juegos\" + nombreArchivo + extension;
                    juegoVM.Juego.FechaCreacion = DateTime.Now.ToString();

                    _contenedorTrabajo.JuegoRep.Update(juegoVM.Juego);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //si la imagen ya existe
                    juegoVM.Juego.UrlImagen = juegoDesdeBD.UrlImagen;
                    _contenedorTrabajo.JuegoRep.Update(juegoVM.Juego);
                    _contenedorTrabajo.Save();

                    return RedirectToAction(nameof(Index));

                }
            }
            juegoVM.ListaCategorias = _contenedorTrabajo.CategoriaRep.GetListaCategorias();
            return View(juegoVM);
        }


        #region Llamadas a la "API"

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.JuegoRep.GetAll(includeProperties: "Categoria") });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _contenedorTrabajo.JuegoRep.Get(id);
            string rutaDirectorioPrincipal = _hostingEnvironment.WebRootPath;
            var rutaImg = Path.Combine(rutaDirectorioPrincipal, objFromDb.UrlImagen.TrimStart('\\'));
            if (System.IO.File.Exists(rutaImg))
            {
                System.IO.File.Delete(rutaImg);
            }
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error borrando Juego" });
            }

            _contenedorTrabajo.JuegoRep.Remove(objFromDb);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Juego Borrado correctamente" });
        }
        #endregion
    }
}
