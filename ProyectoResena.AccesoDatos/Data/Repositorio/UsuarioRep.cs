using Microsoft.EntityFrameworkCore;
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
    public class UsuarioRep : Repositorio<AppUser>, IUsuarioRep
    {
        private readonly ApplicationDbContext _db;
        public UsuarioRep(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void BloquearUsuario(string IdUsuario)
        {
            var usuarioDesdeBd = _db.AppUser.FirstOrDefault(u=> u.Id == IdUsuario);
            usuarioDesdeBd.LockoutEnd = DateTime.Now.AddYears(1000);
            _db.SaveChanges();
        }

        public void DesbloquearUsuario(string IdUsuario)
        {
            var usuarioDesdeBd = _db.AppUser.FirstOrDefault(u => u.Id == IdUsuario);
            usuarioDesdeBd.LockoutEnd = DateTime.Now;
            _db.SaveChanges();
        }
    }
}
