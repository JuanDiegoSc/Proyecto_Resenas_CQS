using System;
using System.Collections.Generic;

namespace Resena_API.Data.Models;

public partial class Juego
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string? FechaCreacion { get; set; }

    public string? UrlImagen { get; set; }

    public int CategoriaId { get; set; }

    public virtual Categoria Categoria { get; set; } = null!;

    public virtual ICollection<Resena> Resenas { get; set; } = new List<Resena>();
}
