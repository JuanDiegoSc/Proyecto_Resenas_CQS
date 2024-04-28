using Microsoft.AspNetCore.Mvc;
using ProyectoResena.AccesoDatos.Data.Repositorio.IRepositorio;
using ProyectoResenas.Models;
using ProyectoResenas.Models.ViewModels;
using System.Diagnostics;

namespace Proyecto_Resenas_CQS.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    public class HomeController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public HomeController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                Sliders = _contenedorTrabajo.SliderRep.GetAll(),
                ListaJuegos = _contenedorTrabajo.JuegoRep.GetAll(),
            };

            ViewBag.IsHome = true;
            return View(homeVM);
        }

        [HttpGet]
        public IActionResult Detalle(int id)
        {
            var juegoDesdeBD = _contenedorTrabajo.JuegoRep.Get(id);
            return View(juegoDesdeBD);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
