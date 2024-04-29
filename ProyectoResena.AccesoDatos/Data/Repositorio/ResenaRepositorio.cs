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
    public class ResenaRepositorio : Repositorio<Resena>, IResenaRepositorio
    {
        private readonly ApplicationDbContext _db;
        public ResenaRepositorio(ApplicationDbContext db) : base(db) 
        {
            _db = db;
        }


        public void Update(Resena resena)
        {
            var objBaseDatos = _db.Resena.FirstOrDefault(s => s.Id == resena.Id);
            objBaseDatos.Puntuacion = resena.Puntuacion;
            objBaseDatos.Comentario = resena.Comentario;

            //_db.SaveChanges();
        }
    }
}
