using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoResenaApp.Data
{
    public interface ISQLite
    {
        string SQLiteLocalPath(string baseDeDatos);
    }
}
