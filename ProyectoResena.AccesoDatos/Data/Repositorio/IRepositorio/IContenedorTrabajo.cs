using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoResena.AccesoDatos.Data.Repositorio.IRepositorio
{
    public interface IContenedorTrabajo : IDisposable //Es una interfaz que implementa el metodo dispose para liberar recursos cuando ya no se necesitan
    {
        //Aqui se deben agregar los diferentes repositorios 
        ICategoriaRepositorio CategoriaRep {  get; }

        void Save();



    }
}
