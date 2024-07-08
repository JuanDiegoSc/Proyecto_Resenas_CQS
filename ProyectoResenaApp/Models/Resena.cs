using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoResenaApp.Models
{
    public class Resena
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string? Usuario { get; set; }
        public string? Comentario { get; set; }
        public int Rating { get; set; }
        public string? GameName { get; set; }
    }
}
