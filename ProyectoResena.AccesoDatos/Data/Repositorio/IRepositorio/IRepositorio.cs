using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoResena.AccesoDatos.Data.Repositorio.IRepositorio
{
    public interface IRepositorio<T>where T : class //Interface de tipo generico sin especificar el tipo de dato
    {
        T Get(int id); //Recibe el id de una entidad 

        IEnumerable<T> GetAll(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string? includeProperties = null //Permite traer datos relacionados
            );

        T GetFirstOrDefault(
            Expression<Func<T, bool>>? filter = null,
            string? includeProperties = null
            );

        void Add( T entity );
        void Remove( int id );
        void Remove( T entity );
    }
}
