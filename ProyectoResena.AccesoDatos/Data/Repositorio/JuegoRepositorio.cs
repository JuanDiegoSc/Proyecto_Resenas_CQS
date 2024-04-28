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
    public class JuegoRepositorio : Repositorio<Juego>, IJuegoRepositorio
    {
        private readonly ApplicationDbContext _db;
        public JuegoRepositorio(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public void Update(Juego juego)
        {
            var objBaseDatos = _db.Juego.FirstOrDefault(s => s.Id == juego.CategoriaId);
            objBaseDatos.Nombre = juego.Nombre;
            objBaseDatos.Descripcion = juego.Descripcion;
            objBaseDatos.UrlImagen = juego.UrlImagen;
            objBaseDatos.CategoriaId = juego.CategoriaId;

            //_db.SaveChanges();
        }
    }
}
