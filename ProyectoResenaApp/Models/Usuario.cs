using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoResenaApp.Models
{
    public class Usuario
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? contra { get; set; }

        public Usuario()
        {
            Id = Guid.NewGuid();
        }
    }
}
