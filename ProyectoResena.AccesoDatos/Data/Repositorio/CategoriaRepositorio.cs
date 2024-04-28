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
    public class CategoriaRepositorio : Repositorio<Categoria>, ICategoriaRepositorio
    {
        private readonly ApplicationDbContext _db;
        public CategoriaRepositorio(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaCategorias()
        {
            return _db.Categoria.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.CategoriaId.ToString()
            });
        }

        public void Update(Categoria categoria)
        {
            var objBaseDatos = _db.Categoria.FirstOrDefault(s => s.CategoriaId == categoria.CategoriaId);
            objBaseDatos.Nombre = categoria.Nombre;
            objBaseDatos.Orden = categoria.Orden;

            //_db.SaveChanges();
        }
    }
}
