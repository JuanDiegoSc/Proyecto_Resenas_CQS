using Microsoft.EntityFrameworkCore.ChangeTracking;
using Proyecto_Resenas_CQS.Data;
using ProyectoResena.AccesoDatos.Data.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoResena.AccesoDatos.Data.Repositorio
{

    //Agrupa varias entidades de datos de manera coherente en una transacción de datos, dentro de esta clase se guardan los repositorios de cada entidad. 
    public class ContenedorTrabajo : IContenedorTrabajo
    {
        private readonly ApplicationDbContext _db;

        public ContenedorTrabajo(ApplicationDbContext db)
        {
            _db = db;
            //Se crean los repositorios 
            CategoriaRep = new CategoriaRepositorio(_db);
            JuegoRep = new JuegoRepositorio(_db);
            SliderRep = new SliderRepositorio(_db);
            ResenaRep = new ResenaRepositorio(_db);
        }

        public ICategoriaRepositorio CategoriaRep {  get; private set; }
        public IJuegoRepositorio JuegoRep { get; private set; }
        public ISliderRepositorio SliderRep { get; private set; }
        public IResenaRepositorio ResenaRep { get; private set; }
        public void Dispose()
        {
           _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
