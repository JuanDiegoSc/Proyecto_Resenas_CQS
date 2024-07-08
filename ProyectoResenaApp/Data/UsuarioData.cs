using ProyectoResenaApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoResenaApp.Data
{
    public class UsuarioData
    {
        public SQLiteAsyncConnection _conexionDB;

        public UsuarioData(SQLiteAsyncConnection conexionDB)
        {
            _conexionDB = conexionDB;
        }

        public Task<List<Usuario>> ListaUsuarios()
        {
            var lista = _conexionDB
                .Table<Usuario>()
                .ToListAsync();

            return lista;
        }

        public Task<Usuario> ObtenerUsuario(string email, string contra)
        {
            var usuario = _conexionDB
                .Table<Usuario>()
                .Where(x => x.Email == email && x.contra== contra)
                .FirstOrDefaultAsync();

            return usuario;
        }
        public Task<Usuario> ObtenerUsuario(Guid id)
        {
            var usuario = _conexionDB
                .Table<Usuario>()
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return usuario;
        }
        public async Task<int> GuardarUsuario(Usuario usuario)
        {
            var usuarioGuardado = await ObtenerUsuario(usuario.Id);

            if(usuarioGuardado == null)
            {
                return await _conexionDB.InsertAsync(usuario);
            }
            else
            {
                return await _conexionDB.UpdateAsync(usuario);
            }
        }

        public async Task<int> BorrarUsuario(Guid id)
        {
            return await _conexionDB.DeleteAsync(id);
        }
        
    }
}
