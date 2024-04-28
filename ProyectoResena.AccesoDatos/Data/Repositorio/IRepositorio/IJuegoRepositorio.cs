using ProyectoResenas.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoResena.AccesoDatos.Data.Repositorio.IRepositorio
{
    public interface IJuegoRepositorio : IRepositorio<Juego>
    {
        void Update(Juego juego);
    }   
}

