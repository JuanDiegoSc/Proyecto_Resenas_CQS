using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Resena_API.Data.Models;

namespace Resena_API.Data
{
    public class Resena_APIContext : DbContext
    {
        public Resena_APIContext (DbContextOptions<Resena_APIContext> options)
            : base(options)
        {
        }

        public DbSet<Resena_API.Data.Models.Categoria> Categoria { get; set; } = default!;
        public DbSet<Resena_API.Data.Models.Juego> Juego { get; set; } = default!;
        public DbSet<Resena_API.Data.Models.Resena> Resena { get; set; } = default!;
    }
}
