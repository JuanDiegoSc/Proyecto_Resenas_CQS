using Microsoft.AspNetCore.Mvc.Rendering;
using Proyecto_Resenas_CQS.Data;
using ProyectoResena.AccesoDatos.Data.Repositorio.IRepositorio;
using ProyectoResenas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoResena.AccesoDatos.Data.Repositorio
{
    public class SliderRepositorio : Repositorio<Slider>, ISliderRepositorio
    {
        private readonly ApplicationDbContext _db;
        public SliderRepositorio(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        

        public void Update(Slider slider)
        {
            var objBaseDatos = _db.Slider.FirstOrDefault(s => s.Id == slider.Id);
            objBaseDatos.Nombre = slider.Nombre;
            objBaseDatos.Estado = slider.Estado;
            objBaseDatos.UrlImagen = slider.UrlImagen;

            //_db.SaveChanges();
        }
    }
}
