using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoResenas.Models;

namespace Proyecto_Resenas_CQS.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //Añadimos el modelo de categoria 
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Juego> Juego { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Resena> Resena { get; set; }
    }
}
