using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProyectoResena.AccesoDatos.Data.Repositorio.IRepositorio;
using ProyectoResenas.Models;
using ProyectoResenas.Models.ViewModels;
using System.Diagnostics;
using System.Drawing.Printing;

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

        //Primera version sin paginación
        //[HttpGet]
        //public IActionResult Index()
        //{
        //    HomeVM homeVM = new HomeVM()
        //    {
        //        Sliders = _contenedorTrabajo.SliderRep.GetAll(),
        //        ListaJuegos = _contenedorTrabajo.JuegoRep.GetAll(),
        //    };

        //    ViewBag.IsHome = true;
        //    return View(homeVM);
        //}

        //Segunda version con paginación
        [HttpGet]
        public IActionResult Index(int page = 1, int pageSize = 2)
        {
            var juegos = _contenedorTrabajo.JuegoRep.AsQueryable();
            var paginatedEntries = juegos.Skip((page - 1) * pageSize).Take(pageSize);

            HomeVM homeVM = new HomeVM()
            {
                Sliders = _contenedorTrabajo.SliderRep.GetAll(),
                ListaJuegos = paginatedEntries.ToList(),
                PageIndex = page,
                TotalPage = (int)Math.Ceiling(juegos.Count() / (decimal)pageSize)
        };

            ViewBag.IsHome = true;
            return View(homeVM);
        }

        //Para buscador
        [HttpGet]
        public IActionResult ResultadoBusqueda(string searchString, int page = 1, int pageSize = 2)
        {
            var juegos = _contenedorTrabajo.JuegoRep.AsQueryable();

            if(!string.IsNullOrEmpty(searchString))
            {
                juegos = juegos.Where(e => e.Nombre.Contains(searchString));
            }

            var paginatedEntries = juegos.Skip((page -1)*pageSize).Take(pageSize);

            var model = new ListaPaginada<Juego>(paginatedEntries.ToList(), juegos.Count(), page, pageSize, searchString);
            return View(model);
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
